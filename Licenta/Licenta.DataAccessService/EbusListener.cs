using CertEntTrust.MW.SDK.Models.Communication;
using Confluent.Kafka;
using Licenta.DataAccessService.Config;
using Licenta.DataAccessService.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;
using System.Text.Json;

namespace Licenta.DataAccessService
{
    // must pe singletone service 
    public class EbusListener : IEbusListener, IDisposable
    {
        // <sessionId, callback with result from kafka to kafkaclient >>>
        private readonly ConcurrentDictionary<string, Func<KafkaResult, Task>>
            SessionNotifiers;
        private readonly Task _consumeTask;
        private readonly KafkaConfig _kafkaConfig;

        public EbusListener(IConfiguration iConfig)
        {
            SessionNotifiers = new ConcurrentDictionary<string, Func<KafkaResult, Task>>();
            _kafkaConfig = new KafkaConfig(iConfig);
            _consumeTask = Task.Run(Consume);
        }


        private async Task Consume()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaConfig.KafkaServer,
                GroupId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Latest
            };
            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(_kafkaConfig.NotifyTopic);
            try
            {

                while (true)
                {
                    var message = consumer.Consume();
                    _ = Task.Run(
                        async () => await Notify(message.Message.Value))
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private async Task Notify(string OutEvent)
        {
            KafkaResult result =
                JsonSerializer.Deserialize<KafkaResult>(OutEvent) ?? new();

            Func<KafkaResult, Task>? sessionNotifier;
            SessionNotifiers.TryGetValue(result.SessionId, out sessionNotifier);
            if (sessionNotifier != null)
                await sessionNotifier.Invoke(result);
        }

        public void Subscribe(string sessionId, Func<KafkaResult, Task> notifyResponse)
        {
            SessionNotifiers.TryAdd(sessionId, notifyResponse);
        }

        public void UnSubscribe(string sessionId)
        {
            SessionNotifiers.Remove(sessionId, out _);
        }

        public void Dispose()
        {
            _consumeTask.Dispose();
        }
    }
}
