using Confluent.Kafka;
using Licenta.Runner.CodeRunners;
using Licenta.SDK.Config;
using Licenta.SDK.Dtos;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Licenta.Runner
{
    internal class KafkaListener
    {
        private readonly KafkaConfig _kafkaConfig;

        public KafkaListener(IConfiguration iConfig)
        {
            _kafkaConfig = new KafkaConfig();
            iConfig.GetSection("AppConfig:Kafka").Bind(_kafkaConfig);   
        }


        private void Consume()
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
                        () =>  RunCode(message.Message.Value))
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void RunCode(string reqJson)
        {
            CodeRunReqDto req = JsonSerializer.Deserialize<CodeRunReqDto>(reqJson) ?? throw new ArgumentException("invalid format for code runner request");
            ICodeRunner? codeRunner = null;
            if(req.Language == "")
            
        }

    }
}
