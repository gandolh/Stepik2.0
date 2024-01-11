using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class ProfessorRepository : BaseRepository<Profesor>
    {
        public ProfessorRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    Firstname VARCHAR(100),
                    Lastname VARCHAR(100),
                    Password VARCHAR(255)
                );
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Profesor data)
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
