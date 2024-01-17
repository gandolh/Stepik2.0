using Confluent.Kafka;
using Licenta.SDK.Models;
using Licenta.SDK.Models.Dtos;
using System.Text.Json;

namespace Licenta.UI.Services
{
    public class KafkaObserver : IKafkaObserver, IDisposable
    {
        private readonly Dictionary<CallbackIdentifier, Func<KafkaDto, Task>> UiNotifiers;
        private CancellationTokenSource _cts;
        private KafkaOptions kafkaOptions;

        public KafkaObserver(LicentaConfig licentaConfig)
        {
            UiNotifiers = new();
            _cts = new CancellationTokenSource();
            kafkaOptions = licentaConfig.Kafka;


            _ = Task.Run(Consume, _cts.Token);
        }

        private async Task Consume()
        {
            var configConsumer = new ConsumerConfig
            {
                GroupId = Guid.NewGuid().ToString(),
                BootstrapServers = kafkaOptions.Address,
                SecurityProtocol = SecurityProtocol.Plaintext,
                AllowAutoCreateTopics = true
            };

            IConsumer<string, string> consumer = new ConsumerBuilder<string, string>(configConsumer).Build();

            consumer.Subscribe(kafkaOptions.SubscribeTopics);

            Console.WriteLine("Incepe consumarea evenimentelor...");

            while (!_cts.Token.IsCancellationRequested)
            {
                ConsumeResult<string, string> consumeResult = consumer.Consume(_cts.Token);

                if (!_cts.IsCancellationRequested)
                    new Task(async () => await this.NotifyAsync(consumeResult)).Start();
            }

            consumer.Unsubscribe();

            // Asigura parasirea grupului si comiterea offset-ului
            consumer.Close();
        }

        public Task AddNotifier(string topicName, string opId, Func<KafkaDto, Task> callback)
        {
            CallbackIdentifier cl = new CallbackIdentifier(topicName, opId);
            if (UiNotifiers.ContainsKey(cl))
                UiNotifiers[cl] = callback;
            else UiNotifiers.Add(cl, callback);
            return Task.CompletedTask;
        }

        public void RemoveNotifier(string topicName, string opId)
        {
            var cl = new CallbackIdentifier(topicName, opId);
            UiNotifiers.Remove(cl);
        }


        public async Task NotifyAsync(ConsumeResult<string, string> consumeResult)
        {
            KafkaDto result = JsonSerializer.Deserialize<KafkaDto>(consumeResult.Message.Value)!;

            // invoke UI callback
            await InvokeCallback(
                consumeResult.Topic,
                result.OperationId,
                result);
        }

        private async Task InvokeCallback(string topicName, string opId, KafkaDto result)
        {
            CallbackIdentifier cl = new CallbackIdentifier(topicName, opId);
            bool found = UiNotifiers.TryGetValue(cl, out var callback);
            if (found)
            {
                UiNotifiers.Remove(cl);
                if (callback != null)
                    await callback.Invoke(result);
            }
        }

        public void Dispose()
        {
            _cts.Cancel();
        }
    }
}
