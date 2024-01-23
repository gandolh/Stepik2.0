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

        public async Task<List<Course>> GetDetailedAsync(bool includeStudents, bool includeTeachers)
        {
            string getCoursesSql = $"SELECT * FROM Course";
            string getTeachersSql = $"SELECT * FROM Teacher";
            string getStudentsSql = $"SELECT * FROM Student";
            string getCourseTeacherSql = $"SELECT * FROM course_teacher";
            string getCourseStudentSql = $"SELECT * FROM student_course";

            var courses = await _dbClient.QueryAsync<Course>(getCoursesSql);
            var teachers = await _dbClient.QueryAsync<Teacher>(getTeachersSql);
            var students = await _dbClient.QueryAsync<Student>(getStudentsSql);
            var teacherCourse = await _dbClient.QueryAsync<Course_Teacher>(getCourseTeacherSql);
            var studentCourse = await _dbClient.QueryAsync<Student_Course>(getCourseStudentSql);

            courses.ForEach(c => {
                var teacherIds = teacherCourse.Where(el => el.CourseId == c.Id).Select(t => t.TeacherId);
                c.Teachers = teachers.Where(t => teacherIds.Contains(t.Id)).ToList();

                var studentIds = studentCourse.Where(el => el.CourseId == c.Id).Select(t => t.StudentId);
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
