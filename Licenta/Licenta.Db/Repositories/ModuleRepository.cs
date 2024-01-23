using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Repositories
{
    public class ModuleRepository : BaseRepository<Module>
    {
        public ModuleRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName}(
                    Id SERIAL PRIMARY KEY,
                    CourseId INT REFERENCES Course(Id),
                    Name VARCHAR(255) DEFAULT ''
                );
                
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Module data)
        {
            string sql = $"""
                INSERT INTO {_tableName}
                (CourseId, Name) 
                VALUES (@CourseId, @Name);
            """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }

        public override async Task UpdateAsync(Module data)
        {
            string sql = $"""
                UPDATE {_tableName} SET 
                CourseId=@CourseId, Name=@Name
                WHERE Id=@Id
                """;
            await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
