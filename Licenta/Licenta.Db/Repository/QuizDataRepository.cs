using Npgsql;

namespace Licenta.Db.Repository
{
    public class QuizDataRepository : BaseRepository, IRepository
    {
        public QuizDataRepository(NpgsqlConnection connection, string? tableName = null) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            string sqlCommand = string.Format(SqlScripts.QuizDataCreate, _tableName);
            ExecSqlCommand(sqlCommand);
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(SqlScripts.QuizDataSeed);
        }
    }
}
