using Licenta.Db.Data;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Repositories
{
    internal class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                DROP TABLE IF EXISTS {_tableName};

                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    Firstname VARCHAR(100),
                    Lastname VARCHAR(100),
                    Password VARCHAR(255)
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Student data)
        {
            string sql = $"""
                INSERT INTO {_tableName}
                (Firstname, Lastname, Password) 
                VALUES (@Firstname,@Lastname,@Password);
            """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
