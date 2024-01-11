using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Repositories
{
    internal class ExerciseRepository : BaseRepository<Exercise>
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
