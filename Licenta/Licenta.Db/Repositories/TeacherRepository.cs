﻿using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>
    {
        public TeacherRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    Firstname VARCHAR(100),
                    Lastname VARCHAR(100),
                    Email VARCHAR(255),
                    Password VARCHAR(255)
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Teacher data)
        {
            string sql = $"""
                INSERT INTO {_tableName}
                (Firstname, Lastname, Email, Password) 
                VALUES (@Firstname,@Lastname, @Email, @Password);
            """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }

        public override async Task UpdateAsync(Teacher data)
        {
            string sql = $"""
                UPDATE {_tableName} SET 
                Firstname=@Firstname, Lastname=@Lastname, Email=@Email
                WHERE Id=@Id
                """;
            await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
