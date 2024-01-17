using Licenta.Runner.CodeRunners;
using Licenta.Sdk.Config;
using Licenta.SDK.Models.Dtos;
using System.Text.Json;

namespace Licenta.Runner
{
    public class RunnerService : BackgroundService
    {
        private readonly KafkaConnector _kafkaConnector;
        private readonly RunnerConfig _runnerConfig;

        public RunnerService(RunnerConfig runnerConfig)
        {
            _kafkaConnector = new KafkaConnector(runnerConfig);
            _runnerConfig = runnerConfig;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = Task.Run(() => _kafkaConnector.Consume(stoppingToken, RunCode));
            return Task.CompletedTask;
        }

        internal async void RunCode(string opId, string reqJson)
        {
            KafkaDto dto = JsonSerializer.Deserialize<KafkaDto>(reqJson);
            CodeRunReqDto reqDto = JsonSerializer.Deserialize<CodeRunReqDto>(dto.Body) ?? new();
            ICodeRunner codeRunner = reqDto.Language switch
            {
                CodeLanguage.Python => new PythonCodeRunner(),
                CodeLanguage.Cpp => new CppCodeRunner(),
                _ => new NullCodeRunner()
            };

            CodeRunResult RunResult = await codeRunner.Run(reqDto);
            KafkaDto kafkaDto = new KafkaDto("", opId, JsonSerializer.Serialize(RunResult));
            _kafkaConnector.Produce(_runnerConfig.Kafka.Endpoints.RunCode,
                Guid.NewGuid().ToString(),
                kafkaDto);
        }
    }
}
