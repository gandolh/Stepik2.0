using Licenta.Db.Data;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTable()
        {
            string sql = $"""
                DROP TABLE IF EXISTS {nameof(Course)};

                CREATE TABLE {nameof(Course)} (
                    Id SERIAL PRIMARY KEY,
                    Name VARCHAR(255)
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }
    }
}
