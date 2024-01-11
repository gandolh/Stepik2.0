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
        private readonly IDbFactory _dbFactory;
        private readonly CourseRepository CourseRepository;
        private readonly TeacherRepository TeacherRepository;
        private readonly StudentRepository StudentRepository;
        private readonly LessonRepository LessonRepository;
        private readonly ExerciseRepository ExerciseRepository;
        private readonly QuizVariantsRepository QuizVariantsRepository;
        private readonly SubmissionRepository SubmissionRepository;
        private readonly StudentCourseRepository StudentCourseRepository;
        private readonly CourseTeacherRepository CourseTeacherRepository;





        public DataSeeder(IDatabaseConnectionSettings settings)
        {
            IDbFactory dbFactory = new NpgsqlDbFactory(settings);
            _dbFactory = dbFactory;
            _dbFactory.Context().Open();
         
            IDapperDbClient dbClient = new DapperDbClient(dbFactory);
            _dbClient = dbClient;
            CourseRepository = new CourseRepository(_dbClient);
            TeacherRepository = new TeacherRepository(_dbClient);
            StudentRepository = new StudentRepository(_dbClient);
            LessonRepository = new LessonRepository(_dbClient);
            ExerciseRepository = new ExerciseRepository(_dbClient);
            QuizVariantsRepository = new QuizVariantsRepository(_dbClient);
            SubmissionRepository = new SubmissionRepository(_dbClient);
            StudentCourseRepository = new StudentCourseRepository(_dbClient);
            CourseTeacherRepository = new CourseTeacherRepository(_dbClient);
        }


        public async Task SeedAsync()
        {

            await DropAll();
            await CreateTables();
            await InsertData();
            await LogResults();
        }

        private async Task DropAll()
        {
            await DropTable(CourseTeacherRepository);
            await DropTable(StudentCourseRepository);
            await DropTable(TeacherRepository);
            await DropTable(QuizVariantsRepository);
            await DropTable(SubmissionRepository);
            await DropTable(ExerciseRepository);
            await DropTable(LessonRepository);
            await DropTable(StudentRepository);
            await DropTable(CourseRepository);
        }

        private async Task CreateTables()
        {
            await CreateTable(CourseRepository);
            await CreateTable(TeacherRepository);
            await CreateTable(StudentRepository);
            await CreateTable(LessonRepository);
            await CreateTable(ExerciseRepository);
            await CreateTable(QuizVariantsRepository);
            await CreateTable(SubmissionRepository);
            await CreateTable(StudentCourseRepository);
            await CreateTable(CourseTeacherRepository);
        }

        private async Task InsertData()
        {
            await GenericInsertData(CourseRepository, DataSampling.GetCourses);
            await GenericInsertData(TeacherRepository, DataSampling.GetTeacher);
            await GenericInsertData(StudentRepository, DataSampling.GetStudents);
            await GenericInsertData(LessonRepository, DataSampling.GetLesson);
            await GenericInsertData(ExerciseRepository, DataSampling.GetExercise);
            await GenericInsertData(QuizVariantsRepository, DataSampling.GetQuizVariants);
            await GenericInsertData(SubmissionRepository, DataSampling.GetSubmissions);
            await GenericInsertData(StudentCourseRepository, DataSampling.GetStudentCourse);
            await GenericInsertData(CourseTeacherRepository, DataSampling.GetCourseTeacher);
        }

        private async Task LogResults()
        {
            await LogResult(CourseRepository);
            await LogResult(TeacherRepository);
            await LogResult(StudentRepository);
            await LogResult(LessonRepository);
            await LogResult(ExerciseRepository);
            await LogResult(QuizVariantsRepository);
            await LogResult(SubmissionRepository);
            await LogResult(StudentCourseRepository);
            await LogResult(CourseTeacherRepository);
        }

        private async Task DropTable<T>(BaseRepository<T> repository)
        {
            await repository.DropTableAsync();
        }

        private async Task CreateTable<T>(BaseRepository<T> repository)
        {
            await repository.CreateTableAsync();
        }

        private async Task GenericInsertData<T>(BaseRepository<T> repository, Func<T[]> getData)
        {
            T[] objects = getData();
            foreach (var obj in objects)
                await repository.InsertAsync(obj);
        }


        private async Task LogResult<T>(BaseRepository<T> repository)
        {
            var insertedData = await repository.GetAllAsync();
            string data = JsonSerializer.Serialize(insertedData);
            Console.WriteLine($"Table: {repository.GetTableName()} \r\n Data: {data}");
        }
    }
}
