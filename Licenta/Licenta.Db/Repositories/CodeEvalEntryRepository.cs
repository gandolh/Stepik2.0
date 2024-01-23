using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Repositories
{
    public class CodeEvalEntryRepository : BaseRepository<CodeEvaluationEntry>
    {
        public CodeEvalEntryRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    ExerciseId INT REFERENCES Exercise(Id),
                    Input TEXT DEFAULT '',
                    ExpectedResult TEXT DEFAULT ''
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(CodeEvaluationEntry data)
        {
            string sql = $"""
                INSERT INTO {_tableName} (ExerciseId, Input, ExpectedResult)
                VALUES (@ExerciseId, @Input, @ExpectedResult);
                """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }

        public override async Task UpdateAsync(CodeEvaluationEntry data)
        {
            string sql = $"""
                UPDATE {_tableName} SET 
                ExerciseId=@ExerciseId, Input=@Input, ExpectedResult=@ExpectedResult
                WHERE Id=@Id
                """;
             await _dbClient.ExecuteAsync(sql, data);
        }

    }
}
