using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Seeder
{
    internal class DatabaseConnectionSettings : IDatabaseConnectionSettings
    {
        public string Host { get; set; } = "";

        public uint Port { get; set; } = 0;

        public string DatabaseName { get; set; } = "";

        public string User { get; set; } = "";

        public string Password { get; set; } = "";

        public bool Pooling { get; set; } = false;
    }
}
