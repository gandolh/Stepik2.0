using Npgsql;

namespace Licenta.Db
{
    public class LicentaContext : IDisposable
    {
        private readonly string _server;
        private readonly string _port;
        private readonly string _database;
        private readonly string _initialDatabase;
        private readonly string _username;
        private readonly string _password;
        private NpgsqlConnection? _connection;
        private string GetConnectionString(bool useInitialDb)
        {
            return $"Host={_server};Port={_port};Username={_username};Password={_password};"
                 + (useInitialDb ? $"Database={_initialDatabase};" : $"Database={_database};");
        }


        public LicentaContext()
        {

            //TODO: read from Iconfiguration
            _server = "postgres";
            _port = "5432";
            _username = "admin";
            _password = "admin";
            _initialDatabase = "my_postgres_database";
            _database = "licenta_db";
        }


        public async Task InitDb()
        {
            await CreateDbIfNotExists();
            await ConnectToDb();
            //CreateDbSchemaIfNotExists();
        }



        private async Task CreateDbIfNotExists()
        {
            string connStr = GetConnectionString(useInitialDb: true);
            _connection = new NpgsqlConnection(connStr);
            await _connection.OpenAsync();

            object? result = DbUtils.GetDatabase(_connection, _database);
            if (result != null && result != DBNull.Value)
                return;
            else
                DbUtils.CreateDb(_connection, _database);
            
            await _connection.CloseAsync();
        }

        private async Task ConnectToDb()
        {
            string connStr = GetConnectionString(useInitialDb: false);
            _connection = new NpgsqlConnection(connStr);
            await _connection.OpenAsync();
        }

        public void CreateDbSchemaIfNotExists()
        {
            //NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            //connection.Open();
        }

        public void CreateDbSchema()
        {

        }

        public void Dispose()
        {
            _connection.Close();
        }
    }


}
