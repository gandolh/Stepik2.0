﻿using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class SubmissionRepository : BaseRepository<Submission>
    {
        public SubmissionRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                DROP TABLE IF EXISTS {_tableName};

                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    Points INT,
                    StudentId INT,
                    ExerciseId INT
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Submission data)
        {
            string sql = $"""
                INSERT INTO {_tableName}
                (Points, StudentId, ExerciseId) 
                VALUES (@Points,@StudentId,@ExerciseId);
            """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
