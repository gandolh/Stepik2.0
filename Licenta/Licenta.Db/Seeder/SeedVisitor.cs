using Licenta.Db.Data;
using Licenta.Db.Repositories;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Seeder
{
    internal class SeedVisitor
    {
        private readonly IDapperDbClient _dbClient;

        public SeedVisitor(IDapperDbClient dbClient)
        {
            _dbClient = dbClient;
        }

        internal async Task SeedCourses()
        {
            CourseRepository cr = new CourseRepository(_dbClient);
            Course course1 = new Course(0, "Structuri de date avansate");
            Course course2 = new Course(1, "programare 1");


            await cr.CreateTableAsync();
            await cr.InsertAsync(course1);
            await cr.InsertAsync(course2);
            //var x = await cr.GetAll();
        }

        internal async Task SeedProfesor()
        {
            ProfessorRepository pr = new ProfessorRepository(_dbClient);
            Profesor professor1 = new Profesor(1, "John", "Doe", "mysecretpassword");
            Profesor professor2 = new Profesor(2, "Jane", "Smith", "anotherpassword");

            await pr.CreateTableAsync();
            await pr.InsertAsync(professor1);
            await pr.InsertAsync(professor2);
            var x = await pr.GetAllAsync();
        }

        internal async Task SeedLesson()
        {
            LessonRepository lr = new LessonRepository(_dbClient);
            Lesson lesson1 = new Lesson(1, 101, "Introduction to Programming");
            Lesson lesson2 = new Lesson(2, 102, "Data Structures and Algorithms");

            await lr.CreateTableAsync();
            await lr.InsertAsync(lesson1);
            await lr.InsertAsync(lesson2);
            var x = await lr.GetAllAsync();
        }

        internal async Task SeedExercise()
        {
            ExerciseRepository er = new ExerciseRepository(_dbClient);

            Exercise exercise1 = new Exercise(1, 101, "Write a program to calculate the sum of two numbers.", 0);
            Exercise exercise2 = new Exercise(2, 102, "Create a quiz on basic mathematics.", 1);

            await er.CreateTableAsync();
            await er.InsertAsync(exercise1);
            await er.InsertAsync(exercise2);
            var x = await er.GetAllAsync();
        }

        internal async Task SeedQuizVariants()
        {
            QuizVariantsRepository qvr = new QuizVariantsRepository(_dbClient);

            QuizVariant variant1 = new QuizVariant(1, 1, "Option A: 10", true);
            QuizVariant variant2 = new QuizVariant(2, 1, "Option B: 15", false);

            await qvr.CreateTableAsync();
            await qvr.InsertAsync(variant1);
            await qvr.InsertAsync(variant2);
            var x = await qvr.GetAllAsync();
        }

        internal async Task SeedStudents()
        {
            StudentRepository sr = new StudentRepository(_dbClient);
            Student student1 = new Student(1, "John", "Doe", "password123");
            Student student2 = new Student(2, "Jane", "Smith", "securepwd");

            await sr.CreateTableAsync();
            await sr.InsertAsync(student1);
            await sr.InsertAsync(student2);

            var x = await sr.GetAllAsync();
        }



    }
}
