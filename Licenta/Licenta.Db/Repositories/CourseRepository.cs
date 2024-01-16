using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;

namespace Licenta.Db.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    Name VARCHAR(255)
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Course data)
        {
            string sql = $"INSERT INTO {_tableName} (Name) VALUES (@Name)";
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }

        public async Task<Course?> GetJoinedCourse(int courseId)
        {
            string sqlGetCourse = $"SELECT * FROM {_tableName} WHERE Id={courseId}";
            Course course = await _dbClient.QueryFirstOrDefaultAsync<Course>(sqlGetCourse);
            if (course == null) return null;

            string sqlGetModules = $"SELECT * FROM Module WHERE CourseId = {courseId}";
            List<Module> modules = await _dbClient.QueryAsync<Module>(sqlGetModules);
            var moduleIds = string.Join(',',modules.Select(m => m.Id));
            string sqlGetLesson = $"SELECT * FROM Lesson WHERE moduleId in ({moduleIds})";
            List<Lesson> lessons = await _dbClient.QueryAsync<Lesson>(sqlGetLesson);


            modules.ForEach(m => m.Lessons = lessons.Where(l => l.ModuleId == m.Id).ToList());

            course.Modules= modules;
            return course;
        }
    }
}
