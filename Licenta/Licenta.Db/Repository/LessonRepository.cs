using Npgsql;

namespace Licenta.Db.Repository
{
    public class LessonRepository : BaseRepository, IRepository
    {
        public LessonRepository(NpgsqlConnection connection, string? tableName = null) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            string sqlCommand = string.Format(SqlScripts.LessonCreate, _tableName);
            ExecSqlCommand(sqlCommand);
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(SqlScripts.LessonSeed);
        }
    }
}
