using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class LessonRepository : BaseRepository<Lesson>
    {
        public LessonRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName}(
                    Id SERIAL PRIMARY KEY,
                    ModuleId INT REFERENCES Module(Id),
                    Name VARCHAR(255),
                    Body VARCHAR(10000)
                );
                
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Lesson data)
        {
            string sql = $"""
                INSERT INTO {_tableName}
                (ModuleId, Name, Body) 
                VALUES (@ModuleId, @Name, @Body);
            """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
