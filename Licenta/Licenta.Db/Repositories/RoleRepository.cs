using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $@"
                CREATE TABLE IF NOT EXISTS {_tableName} (
                    Id SERIAL PRIMARY KEY,
                    UserId INT REFERENCES PortalUser(Id),
                    Type INT
                );
            ";
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Role data)
        {
            string sql = $@"
                INSERT INTO {_tableName}
                (UserId, Type) 
                VALUES (@UserId, @Type);
            ";
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }

        public override async Task UpdateAsync(Role data)
        {
            string sql = $@"
                UPDATE {_tableName} SET 
                Type = @Type,
                UserId = @UserId
                WHERE Id = @Id;
            ";
            await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
