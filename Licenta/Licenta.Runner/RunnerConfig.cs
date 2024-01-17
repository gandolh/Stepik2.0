namespace Licenta.Runner
{
    public class RunnerConfig
    {
        public KafkaOptions Kafka { get; set; } = new();

        public RunnerConfig(IConfiguration iConfig)
        {
            iConfig.GetSection("AppConfig").Bind(this);
        }
    }
}
