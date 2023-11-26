using Microsoft.Extensions.Configuration;

namespace Licenta.Sdk.Config
{
    public class RedisConfig
    {
        public RedisConfig(IConfiguration iConfig)
        {

            iConfig.Bind(this);
        }

        public string RedisEndpoint { get; set; } = "";
    }
}
