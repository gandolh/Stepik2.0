using Npgsql;
using System.Data;

namespace Licenta.Db.Repository
{
    internal class CourseRepository : BaseRepository, IRepository
    {
        public CourseRepository(NpgsqlConnection connection, string tableName) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            string sqlCommand = string.Format(SqlScripts.CoursesCreate, _tableName);
            ExecSqlCommand(sqlCommand);
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(SqlScripts.CoursesSeed);
        }


    }
}
