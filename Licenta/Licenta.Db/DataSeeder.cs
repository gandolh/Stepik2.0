using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.Db.Seeder;
using Licenta.Db.Seeder.Interfaces;
using System.Text.Json;

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


        public async Task SeedAsync()
        {
            await SeedCourseAsync();
            await SeedProfesorAsync();
            await SeedLessonAsync();
            await SeedExerciseAsync();
            await SeedQuizVariantAsync();
            await SeedStudentAsync();
            await SeedSubmissionAsync();
            await SeedCourseProfesorAsync();
            await SeedStudentCourseAsync();
        }


        internal async Task SeedCourseAsync()
        {
            CourseRepository cr = new CourseRepository(_dbClient);
            var objects = DataSampling.GetCourses();
            await BuildSchemaAsync(cr, objects);
        }

        internal async Task SeedProfesorAsync()
        {
            ProfessorRepository pr = new ProfessorRepository(_dbClient);
            var objects = DataSampling.GetProfesor();
            await BuildSchemaAsync(pr, objects);
        }

        internal async Task SeedStudentAsync()
        {
            StudentRepository sr = new StudentRepository(_dbClient);
            var objects = DataSampling.GetStudents();
            await BuildSchemaAsync(sr, objects);
        }

        internal async Task SeedLessonAsync()
        {
            LessonRepository lr = new LessonRepository(_dbClient);
            var objects = DataSampling.GetLesson();
            await BuildSchemaAsync(lr, objects);
        }

        internal async Task SeedExerciseAsync()
        {
            ExerciseRepository er = new ExerciseRepository(_dbClient);
            var objects = DataSampling.GetExercise();
            await BuildSchemaAsync(er, objects);
        }

        internal async Task SeedQuizVariantAsync()
        {
            QuizVariantsRepository qvr = new QuizVariantsRepository(_dbClient);
            var objects = DataSampling.GetQuizVariants();
            await BuildSchemaAsync(qvr, objects);
        }

        internal async Task SeedSubmissionAsync()
        {
            SubmissionRepository sr = new SubmissionRepository(_dbClient);
            var objects = DataSampling.GetSubmissions();
            await BuildSchemaAsync(sr, objects);
        }

        private async Task SeedStudentCourseAsync()
        {
            StudentCourseRepository scr = new StudentCourseRepository(_dbClient);
            var objects = DataSampling.GetStudentCourse();
            await BuildSchemaAsync(scr, objects);
        }

        private async Task SeedCourseProfesorAsync()
        {
            CourseProfessorRepository cpr = new CourseProfessorRepository(_dbClient);
            var objects = DataSampling.GetCourseProfesor();
            await BuildSchemaAsync(cpr, objects);
        }


        private async Task BuildSchemaAsync<T>(BaseRepository<T> repository, T[] objects)
        {
            await repository.CreateTableAsync();
            foreach (var obj in objects)
                await repository.InsertAsync(obj);

            var insertedData = await repository.GetAllAsync();
            string data = JsonSerializer.Serialize(insertedData);
            Console.WriteLine($"Table: {repository.GetTableName()} \r\n Data: {data}");
        }
    }
}
