using Microsoft.Extensions.Configuration;

namespace Licenta.Sdk.Config
{
    public class KafkaConfig
    {
        public KafkaConfig() { }
        public KafkaConfig(IConfiguration iConfig)
        {
            iConfig.Bind(this);
        }

        public string KafkaServer { get; set; } = "";
        public string NotifyTopic { get; set; } = "";
        public string RunCodeTopic { get; set; } = "";
    }
}
