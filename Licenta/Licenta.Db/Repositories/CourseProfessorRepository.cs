using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Repositories
{
    internal class CourseProfessorRepository : BaseRepository<Course_Professor>
    {
        public CourseProfessorRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                DROP TABLE IF EXISTS {_tableName};

                CREATE TABLE {_tableName} (
                    CourseId INT,
                    ProfessorId INT
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Course_Professor data)
        {
            string sql = $"INSERT INTO {_tableName} (CourseId, ProfessorId) VALUES (@CourseId, @ProfessorId)";
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
