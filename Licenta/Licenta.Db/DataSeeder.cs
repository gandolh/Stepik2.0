using Licenta.Db.Data;
using Licenta.Db.DataModel;
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
            var SeedVisitor = new SeedVisitor(_dbClient);
            await SeedVisitor.SeedCourses();
            await SeedVisitor.SeedProfesor();
            await SeedVisitor.SeedLesson();
            await SeedVisitor.SeedExercise();
            await SeedVisitor.SeedQuizVariants();
            await SeedVisitor.SeedStudents();

        }

  






    }
}
