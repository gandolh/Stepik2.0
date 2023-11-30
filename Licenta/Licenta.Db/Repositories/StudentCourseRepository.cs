using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    internal class StudentCourseRepository : BaseRepository<Student_Course>
    {
        public StudentCourseRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                DROP TABLE IF EXISTS {_tableName};

                CREATE TABLE {_tableName} (
                    StudentId INT,
                    CourseId INT
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Student_Course data)
        {
            string sql = $"INSERT INTO {_tableName} (StudentId, CourseId) VALUES (@StudentId, @CourseId)";
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
