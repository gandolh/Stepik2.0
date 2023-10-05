using Licenta.Runner.CodeRunners;
using Licenta.Sdk.Config;
using Licenta.Sdk.Models.Data;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Mappers;
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
#if DEBUG
            _ = Task.Run(() => ListenForSignal());
#endif
            return Task.CompletedTask;
        }

        private async Task ListenForSignal()
        {
            File.WriteAllText("commands.txt", "");
            while (true)
            {

                try
                {
                    string content = File.ReadAllText("commands.txt").Trim();
                    if (content.EndsWith('!'))
                    {
                        File.WriteAllText("commands.txt", "");
                        _kafkaConnector.Produce(Guid.NewGuid().ToString(), content.Substring(0, content.Length - 1));
                    }
                }
                catch (Exception ex)
                {

                }
                await Task.Delay(1000);
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
