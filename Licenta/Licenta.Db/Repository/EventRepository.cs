using Licenta.Db.Data;
using Npgsql;

namespace Licenta.Db.Repository
{
    public class EventRepository : BaseRepository, IRepository
    {
        public EventRepository(NpgsqlConnection connection, string? tableName = null) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            string sqlCommand = string.Format(SqlScripts.EventsCreate, _tableName);
            ExecSqlCommand(sqlCommand);
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(SqlScripts.EventsSeed );
        }
    }
}
