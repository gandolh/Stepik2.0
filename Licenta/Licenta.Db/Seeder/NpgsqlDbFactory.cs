using Licenta.Db.Seeder.Interfaces;
using Npgsql;
using System.Data;

namespace Licenta.Db.Seeder
{
    public class NpgsqlDbFactory : DbFactory
    {
        public NpgsqlDbFactory(IDatabaseConnectionSettings connectionSettings) :
            base(CreateConnectionString(connectionSettings))
        {
        }

        public override IDbConnection Connection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }

        private static string CreateConnectionString(IDatabaseConnectionSettings settings)
        {
            return $"User ID={settings.User};Password={settings.Password};Host={settings.Host};Port={settings.Port};Database={settings.DatabaseName};Pooling={settings.Pooling};";
        }
    }
}
