using Npgsql;

namespace Licenta.Db.Repository
{
    public class BaseRepository
    {
        protected readonly string? _tableName;
        protected readonly NpgsqlConnection _connection;

        public BaseRepository(NpgsqlConnection connection, string? tableName)
        {
            _tableName = tableName;
            _connection = connection;
        }

        public void ExecSqlCommand(string sqlCommand)
        {
            using NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = _connection;
            command.CommandText = sqlCommand;
            command.ExecuteNonQuery();
        }
    }
}
