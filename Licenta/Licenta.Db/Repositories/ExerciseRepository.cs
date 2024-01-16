using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class ExerciseRepository : BaseRepository<Exercise>
    {
        public ExerciseRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    LessonId INT REFERENCES Lesson(Id),
                    Enunciation TEXT,
                    Type INT
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Exercise data)
        {
            string sql = $"""
                INSERT INTO {_tableName} (LessonId, Enunciation, Type)
                VALUES (@LessonId, @Enunciation, @Type);
                """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
