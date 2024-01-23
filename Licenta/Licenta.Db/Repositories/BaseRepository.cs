using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected readonly IDapperDbClient _dbClient;
        protected readonly string _tableName;

        public BaseRepository(IDapperDbClient dbClient)
        {
            _dbClient = dbClient;
            _tableName = typeof(T).Name;
        }

        public string GetTableName()
        {
            return _tableName;
        }

        public abstract Task CreateTableAsync();
        public async Task DropTableAsync()
        {
            await _dbClient.ExecuteAsync($"""
                DROP TABLE IF EXISTS {_tableName};
                """);
        }
        public abstract Task InsertAsync(T data);

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }


        public async Task<List<T>> GetAllAsync(int start = 0, int length = 25)
        {
            string sql = $"SELECT * FROM {_tableName} OFFSET {start} LIMIT {length}";
             return await _dbClient.QueryAsync<T>(sql);

        }

        public async Task<T> GetOneAsync(int id)
        {
            string sql = $"SELECT * FROM {_tableName} where Id={id}";
            return await _dbClient.QueryFirstOrDefaultAsync<T>(sql);
        }


        public abstract Task UpdateAsync(T data);
    }
}
