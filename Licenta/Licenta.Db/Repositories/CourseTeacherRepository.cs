using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Repositories
{
    internal class CourseTeacherRepository : BaseRepository<Course_Teacher>
    {
        public CourseTeacherRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName} (
                    CourseId INT REFERENCES Course(Id),
                    TeacherId INT REFERENCES Teacher(Id)
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Course_Teacher data)
        {
            string sql = $"INSERT INTO {_tableName} (CourseId, TeacherId) VALUES (@CourseId, @TeacherId)";
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }

        public override async Task UpdateAsync(Course_Teacher data)
        {
            string sql = $"""
                UPDATE {_tableName} SET 
                CourseId=@CourseId, TeacherId=@TeacherId
                WHERE Id=@Id
                """;
            await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
