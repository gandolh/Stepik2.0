using Confluent.Kafka;
using Licenta.Sdk.Config;
using Licenta.SDK.Models.Dtos;
using System.Text.Json;

namespace Licenta.Runner
{
    internal class KafkaConnector
    {
        private readonly KafkaOptions _kafkaConfig;
        private IProducer<string, string> _producer;

        internal KafkaConnector(RunnerConfig runnerConfig)
        { 
            _kafkaConfig = runnerConfig.Kafka;
            var config = new ProducerConfig()
            {
                BootstrapServers = _kafkaConfig.Address
            };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public void Consume(CancellationToken stoppingToken, Action<string, string> callback)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaConfig.Address,
                GroupId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Latest,
                AllowAutoCreateTopics = true
            };
            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(_kafkaConfig.SubscribeTopics);
            try
            {

                while (!stoppingToken.IsCancellationRequested)
                {
                    var message = consumer.Consume(stoppingToken);
                    if (stoppingToken.IsCancellationRequested) return;
                    _ = Task.Run(() => callback(message.Message.Key, message.Message.Value));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void Produce(string topicName, string key, KafkaDto value)
        {
            var message = new Message<string, string>();
            message.Key = key;
            message.Value = JsonSerializer.Serialize(value);
            _producer.Produce( topicName, message);
        }
    }
}