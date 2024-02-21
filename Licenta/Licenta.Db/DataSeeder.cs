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
        private readonly RoleRepository RoleRepository;
        private readonly UserRepository UserRepository;
        private readonly ModuleRepository ModuleRepository;
        private readonly LessonRepository LessonRepository;
        private readonly ExerciseRepository ExerciseRepository;
        private readonly CodeEvalEntryRepository CodeEvaluationEntryRepository;
        private readonly QuizVariantsRepository QuizVariantsRepository;
        private readonly SubmissionRepository SubmissionRepository;
        private readonly CourseUserRepository CourseUserRepository;





        public DataSeeder(IDatabaseConnectionSettings settings)
        {
            IDbFactory dbFactory = new NpgsqlDbFactory(settings);
            _dbFactory = dbFactory;
         
            IDapperDbClient dbClient = new DapperDbClient(dbFactory);
            _dbClient = dbClient;
            CourseRepository = new CourseRepository(_dbClient);
            RoleRepository = new RoleRepository(_dbClient);
            UserRepository = new UserRepository(_dbClient);
            ModuleRepository = new ModuleRepository(_dbClient);
            LessonRepository = new LessonRepository(_dbClient);
            ExerciseRepository = new ExerciseRepository(_dbClient);
            QuizVariantsRepository = new QuizVariantsRepository(_dbClient);
            CodeEvaluationEntryRepository = new CodeEvalEntryRepository(_dbClient);
            SubmissionRepository = new SubmissionRepository(_dbClient);
            CourseUserRepository = new CourseUserRepository(_dbClient);
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
            await DropTable(QuizVariantsRepository);
            await DropTable(CodeEvaluationEntryRepository);
            await DropTable(SubmissionRepository);
            await DropTable(ExerciseRepository);
            await DropTable(LessonRepository);
            await DropTable(ModuleRepository);
            await DropTable(RoleRepository);
            await DropTable(CourseUserRepository);
            await DropTable(UserRepository);
            await DropTable(CourseRepository);
        }

        private async Task CreateTables()
        {
            await CreateTable(CourseRepository);
            await CreateTable(UserRepository);
            await CreateTable(RoleRepository);
            await CreateTable(ModuleRepository);
            await CreateTable(LessonRepository);
            await CreateTable(ExerciseRepository);
            await CreateTable(QuizVariantsRepository);
            await CreateTable(CodeEvaluationEntryRepository);
            await CreateTable(SubmissionRepository);
            await CreateTable(CourseUserRepository);
        }

        private async Task InsertData()
        {
            await GenericInsertData(CourseRepository, DataSampling.GetCourses);
            await GenericInsertData(UserRepository, DataSampling.GetUsers);
            await GenericInsertData(RoleRepository, DataSampling.GetRole);
            await GenericInsertData(ModuleRepository, DataSampling.GetModules);
            await GenericInsertData(LessonRepository, DataSampling.GetLessons);
            await GenericInsertData(ExerciseRepository, DataSampling.GetExercise);
            await GenericInsertData(QuizVariantsRepository, DataSampling.GetQuizVariants);
            await GenericInsertData(CodeEvaluationEntryRepository, DataSampling.GetCodeEvaluationEntry);
            await GenericInsertData(SubmissionRepository, DataSampling.GetSubmissions);
            await GenericInsertData(CourseUserRepository, DataSampling.GetCourseUser);
        }

        private async Task LogResults()
        {
            await LogResult(CourseRepository);
            await LogResult(UserRepository);
            await LogResult(RoleRepository);
            await LogResult(ModuleRepository);
            await LogResult(LessonRepository);
            await LogResult(ExerciseRepository);
            await LogResult(QuizVariantsRepository);
            await LogResult(CodeEvaluationEntryRepository);
            await LogResult(SubmissionRepository);
            await LogResult(CourseUserRepository);
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
