using Licenta.Db.Data;
using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;
using Licenta.SDK.Models;
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

        public async Task<Course?> GetFullOne(int courseId)
        {
            string sqlGetCourse = $"SELECT * FROM {_tableName} WHERE Id={courseId}";
            Course course = await _dbClient.QueryFirstOrDefaultAsync<Course>(sqlGetCourse);
            if (course == null) return null;

            string sqlGetModules = $"SELECT * FROM Module WHERE CourseId = {courseId}";
            List<Module> modules = await _dbClient.QueryAsync<Module>(sqlGetModules);
            var moduleIds = string.Join(',', modules.Select(m => m.Id));
            string sqlGetLesson = $"SELECT * FROM Lesson WHERE moduleId in ({moduleIds})";
            List<Lesson> lessons = await _dbClient.QueryAsync<Lesson>(sqlGetLesson);

            var lessonsIds = string.Join(',', lessons.Select(el => el.Id));
            string sqlGetExercises = $"SELECT * FROM Exercise WHERE lessonId in ({lessonsIds})";
            List<Exercise> exercises = await _dbClient.QueryAsync<Exercise>(sqlGetExercises);

            
            lessons.ForEach(l => l.Exercises = exercises.Where(e => e.LessonId == l.Id).ToList());
            modules.ForEach(m => m.Lessons = lessons.Where(l => l.ModuleId == m.Id).ToList());

            course.Modules = modules;
            return course;
        }

        public async Task<List<Course>> GetFullAll()
        {
            string getCoursesSql = $"SELECT * FROM Course";

            //todo replace
            string getTeachersSql = $"SELECT * FROM PortalUser INNER JOIN Role ON PortalUser.Id = Role.UserId where type={(int)RoleType.Teacher}";
            string getStudentsSql = $"SELECT * FROM PortalUser INNER JOIN Role ON PortalUser.Id = Role.UserId where type={(int)RoleType.Student}";
            string getCourseUserSql = $"SELECT * FROM course_user";

            var courses = await _dbClient.QueryAsync<Course>(getCoursesSql);
            var teachers = await _dbClient.QueryAsync<PortalUser>(getTeachersSql);
            var students = await _dbClient.QueryAsync<PortalUser>(getStudentsSql);
            var usersCourse = await _dbClient.QueryAsync<Course_User>(getCourseUserSql);

            courses.ForEach(c =>
            {
                var teacherIds = usersCourse.Where(el => el.CourseId == c.Id && el.ParticipationType == 1).Select(t => t.UserId);
                c.Teachers = teachers.Where(t => teacherIds.Contains(t.Id)).ToList();

                var studentIds = usersCourse.Where(el => el.CourseId == c.Id && el.ParticipationType == 0).Select(t => t.UserId);
                c.Students = students.Where(t => studentIds.Contains(t.Id)).ToList();
            });

            return courses;
        }

        public override async Task UpdateAsync(Course data)
        {
            string sql = $"""
                UPDATE {_tableName} SET 
                Name=@Name
                WHERE Id=@Id
                """;
            await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
