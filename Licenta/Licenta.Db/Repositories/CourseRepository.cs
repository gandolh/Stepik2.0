using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

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
                DROP TABLE IF EXISTS {_tableName};

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
    }
}
