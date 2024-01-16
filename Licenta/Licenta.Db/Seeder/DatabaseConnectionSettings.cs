using Licenta.Db.Seeder.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Licenta.Db.Seeder
{
    public class DatabaseConnectionSettings : IDatabaseConnectionSettings
    {
        public DatabaseConnectionSettings()
        {
            
        }

        public DatabaseConnectionSettings(IConfiguration iConfig)
        {
            iConfig.GetSection("Database").Bind(this);
        }
        public string Host { get; set; } = "";

        public uint Port { get; set; } = 0;

        public string DatabaseName { get; set; } = "";

        public string User { get; set; } = "";

        public string Password { get; set; } = "";

        public bool Pooling { get; set; } = false;
    }
}
