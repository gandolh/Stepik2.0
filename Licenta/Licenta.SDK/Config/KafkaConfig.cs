using Microsoft.Extensions.Configuration;

namespace Licenta.DataAccessService.Config
{
    public class KafkaConfig
    {
        public KafkaConfig(IConfiguration iConfig)
        {
            iConfig.Bind(this);
        }

        public string KafkaServer { get; set; } = "";
        public string NotifyTopic { get; set; } = "";
    }
}
