using Licenta.Db.Seeder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public Task GetOneAsync(string id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateAsync(T data)
        {
            throw new NotImplementedException();
        }
    }
}
