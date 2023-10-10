using Npgsql;

namespace Licenta.Db.Repository
{
    public class LastAccesedRepository : BaseRepository, IRepository
    {
        public LastAccesedRepository(NpgsqlConnection connection, string tableName) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            string sqlCommand = string.Format(SqlScripts.LastAccesedCreate, _tableName);
            ExecSqlCommand(sqlCommand);

        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand( SqlScripts.LastAccesedSeed);
        }
    }
}
