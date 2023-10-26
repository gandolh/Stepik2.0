using Licenta.Db.Data;
using Npgsql;

namespace Licenta.Db.Repository
{
    public class LastAccesedRepository : BaseRepository, IRepository
    {
        public LastAccesedRepository(NpgsqlConnection connection, string? tableName = null) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            string sqlCommand = string.Format(SqlScripts.LastAccesedCreate, _tableName);
            ExecSqlCommand(sqlCommand);

        }

        public IEnumerable<LastAccesed> GetAll(string? userId = "")
        {
            throw new NotImplementedException();
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand( SqlScripts.LastAccesedSeed);
        }
    }
}
