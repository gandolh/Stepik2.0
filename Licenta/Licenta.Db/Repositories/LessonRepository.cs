using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    CourseId INT REFERENCES Course(Id),
                    Name VARCHAR(255)
                );
                
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Lesson data)
        {
            string sql = $"""
                INSERT INTO {_tableName}
                (CourseId, Name) 
                VALUES (@CourseId, @Name);
            """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
