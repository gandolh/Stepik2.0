using Licenta.Runner.CodeRunners;
using Licenta.Sdk.Config;
using Licenta.SDK.Models.Dtos;
using System.Text.Json;

namespace Licenta.Runner
{
    public class RunnerService : BackgroundService
    {
        private readonly KafkaConnector _kafkaConnector;
        private readonly KafkaConfig _kafkaConfig;

        public RunnerService(IConfiguration iConfig)
        {
            _kafkaConfig = new KafkaConfig();
            iConfig.GetSection("AppConfig:Kafka").Bind(_kafkaConfig);
            _kafkaConnector = new KafkaConnector(_kafkaConfig);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = Task.Run(() => _kafkaConnector.Consume(stoppingToken, new string[] { _kafkaConfig.RunCodeTopic }, RunCode));
            return Task.CompletedTask;
        }

        internal void RunCode(string reqJson)
        {
            CodeRunReqDto dto = JsonSerializer.Deserialize<CodeRunReqDto>(reqJson) ?? new();

            ICodeRunner codeRunner = dto.Language switch
            {
                CodeLanguage.Python => new PythonCodeRunner(),
                CodeLanguage.Cpp => new CppCodeRunner(),
                _ => new NullCodeRunner()
            };

            var result = codeRunner.Run(dto);
        }

    }
            //var codeRunReq = mapper.Map(dto);
}
