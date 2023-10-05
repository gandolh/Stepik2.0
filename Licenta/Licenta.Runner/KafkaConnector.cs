using Confluent.Kafka;
using Licenta.Sdk.Config;

namespace Licenta.Runner
{
    public class KafkaConnector
    {
        private readonly KafkaConfig _kafkaConfig;
        private IProducer<string, string> _producer;

        public KafkaConnector(KafkaConfig kafkaConfig)
        { 
            _kafkaConfig = kafkaConfig;
            var config = new ProducerConfig()
            {
                BootstrapServers = _kafkaConfig.KafkaServer
            };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public void Consume(CancellationToken stoppingToken, string[] subscribeTopics, Action<string> callback)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaConfig.KafkaServer,
                GroupId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Latest
            };
            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(subscribeTopics);
            try
            {

                while (true)
                {
                    var message = consumer.Consume(stoppingToken);
                    if (stoppingToken.IsCancellationRequested) return;

                    _ = Task.Run(
                        () => callback(message.Message.Value))
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void Produce(string? key = null, string? value = null)
        {
            var message = new Message<string, string>();
            message.Key = key ?? Guid.NewGuid().ToString();
            message.Value = value ?? "";
            _producer.Produce(_kafkaConfig.RunCodeTopic, message);
        }
    }
}