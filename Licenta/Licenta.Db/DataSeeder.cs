using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db
{
    internal class DataSeeder
    {
        public DataSeeder(IDapperDbClient dbClient)
        {
            
        }


        public Task Seed()
        {

            return Task.CompletedTask;
        }
    }
}
