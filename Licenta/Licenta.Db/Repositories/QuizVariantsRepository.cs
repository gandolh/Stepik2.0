using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class QuizVariantsRepository : BaseRepository<QuizVariant>
    {
        public QuizVariantsRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    ExerciseId INT REFERENCES Exercise(Id),
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

        public override async Task UpdateAsync(QuizVariant data)
        {
            string sql = $"""
                UPDATE {_tableName} SET 
                ExerciseId=@ExerciseId, Text=@Text, IsCorrect=@IsCorrect
                WHERE Id=@Id
                """;
            await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
