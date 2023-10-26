using Licenta.Db.Data;
using Npgsql;
using System.Data;

namespace Licenta.Db.Repository
{
    public class CourseRepository : BaseRepository, IRepository
    {
        public CourseRepository(NpgsqlConnection connection, string? tableName = null) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            string sqlCommand = string.Format(SqlScripts.CoursesCreate, _tableName);
            ExecSqlCommand(sqlCommand);
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public Course GetOne(string courseId)
        {
            throw new NotImplementedException();
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(SqlScripts.CoursesSeed);
        }


    }
}
