using Licenta.Db.Data;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Repositories
{
    internal class QuizVariantsRepository : BaseRepository<QuizVariant>
    {
        public QuizVariantsRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                DROP TABLE IF EXISTS {_tableName};

                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    ExerciseId INT,
                    Text VARCHAR(255),
                    IsCorrect BOOLEAN
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(QuizVariant data)
        {
            string sql = $"""
                INSERT INTO {_tableName} (ExerciseId, Text, IsCorrect)
                VALUES (@ExerciseId, @Text, @IsCorrect);
                """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
