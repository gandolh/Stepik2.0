using Confluent.Kafka;
using Licenta.Runner.CodeRunners;
using Licenta.Sdk.Config;
using Licenta.Sdk.Models.Data;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Licenta.Runner
{
    internal class KafkaListener : BackgroundService
    {
        private readonly KafkaConfig _kafkaConfig;

        public KafkaListener(IConfiguration iConfig)
        {
            _kafkaConfig = new KafkaConfig();  
            iConfig.GetSection("AppConfig:Kafka").Bind(_kafkaConfig);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Consume(stoppingToken);
            return Task.CompletedTask;
        }

        private void Consume(CancellationToken stoppingToken)
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
                    var message = consumer.Consume(stoppingToken);
                    if (stoppingToken.IsCancellationRequested) return;

                    _ = Task.Run(
                        () => RunCode(message.Message.Value))
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
            CodeRunReqDto dto = JsonSerializer.Deserialize<CodeRunReqDto>(reqJson) ?? new();
            MapperBase<CodeRunReq, CodeRunReqDto> mapper = new CodeRunReqMapper();
            var codeRunReq = mapper.Map(dto);

            ICodeRunner codeRunner = codeRunReq.Language switch
            {
                CodeLanguage.Python => new PythonCodeRunner(),
                CodeLanguage.Cpp => new CppCodeRunner(),
                _ => new NullCodeRunner()
            };

            var result = codeRunner.Run(codeRunReq);
        }

    }
}
