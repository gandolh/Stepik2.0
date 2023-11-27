using Licenta.Db.Repositories;
using Licenta.Db.Seeder;
using Licenta.Db.Seeder.Interfaces;
using Licenta.Db.Data;

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

        }

        private async Task SeedCourses()
        {
            CourseRepository cr = new CourseRepository(_dbClient);
            Course course1 = new Course(0, "Structuri de date avansate");
            Course course2 = new Course(1, "programare 1");


            await cr.CreateTable();
            //cr.Insert(course1);
            //cr.Insert(course2);
        }
    }
}
