using Npgsql;

namespace Licenta.Db.Repository
{
    public class EventRepository : BaseRepository, IRepository
    {
        public EventRepository(NpgsqlConnection connection, string tableName) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            string sqlCommand = string.Format(SqlScripts.EventsCreate, _tableName);
            ExecSqlCommand(sqlCommand);
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(SqlScripts.EventsSeed );
        }
    }
}
