using Licenta.Db.Data;
using Licenta.Db.Repositories;
using Licenta.Db.Seeder;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db
{
    internal class DataSeeder
    {
        private readonly IDapperDbClient _dbClient;

        public DataSeeder(IDatabaseConnectionSettings settings)
        {
            IDbFactory dbFactory = new NpgsqlDbFactory(settings);
            dbFactory.Context().Open();
            var transaction = dbFactory.Context().BeginTransaction();
            IDapperDbClient dbClient = new DapperDbClient(dbFactory, transaction);
            _dbClient = dbClient;
        }


        public async Task Seed()
        {
            await SeedCourses();
            await SeedProfesor();
            await SeedLesson();

        }

        private async Task SeedCourses()
        {
            CourseRepository cr = new CourseRepository(_dbClient);
            Course course1 = new Course(0, "Structuri de date avansate");
            Course course2 = new Course(1, "programare 1");


            await cr.CreateTable();
            await cr.Insert(course1);
            await cr.Insert(course2);
            //var x = await cr.GetAll();
        }

        private async Task SeedProfesor()
        {
            ProfessorRepository pr = new ProfessorRepository(_dbClient);
            Profesor professor1 = new Profesor(1, "John", "Doe", "mysecretpassword");
            Profesor professor2 = new Profesor(2, "Jane", "Smith", "anotherpassword");

            await pr.CreateTable();
            await pr.Insert(professor1);
            await pr.Insert(professor2);
            var x = await pr.GetAll();
        }

        private async Task SeedLesson()
        {
            LessonRepository lr = new LessonRepository(_dbClient);
            Lesson lesson1 = new Lesson(1, 101, "Introduction to Programming");
            Lesson lesson2 = new Lesson(2, 102, "Data Structures and Algorithms");

            await lr.CreateTable();
            await lr.Insert(lesson1);
            await lr.Insert(lesson2);
            var x = await lr.GetAll();
        }




    }
}
