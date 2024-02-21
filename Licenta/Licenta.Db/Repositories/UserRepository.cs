using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class UserRepository : BaseRepository<PortalUser>
    {
        public UserRepository(IDapperDbClient dbClient) : base(dbClient)
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

        public override async Task InsertAsync(PortalUser data)
        {
            string sql = $"""
                INSERT INTO {_tableName}
                (Firstname, Lastname, Email, Password) 
                VALUES (@Firstname,@Lastname,@Email,@Password);
            """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }

        public override async Task UpdateAsync(PortalUser data)
        {
            string sql = $"""
                UPDATE {_tableName} SET 
                Firstname=@Firstname, Lastname=@Lastname, Email=@Email
                WHERE Id=@Id
                """;
            await _dbClient.ExecuteAsync(sql, data);
        }

        public async Task<PortalUser> GetOne(string email)
        {
            string sqlGetAllUsers = $"SELECT * FROM PortalUser where Email='{email}'";
            PortalUser? user = await _dbClient.QueryFirstOrDefaultAsync<PortalUser>(sqlGetAllUsers);
            return user;
        }
    }
}
