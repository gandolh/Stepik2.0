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

        public BaseRepository(IDapperDbClient dbClient)
        {
            _dbClient = dbClient;
        }

        public abstract Task CreateTable();
        public async Task DropTable()
        {
            string tableName = typeof(T).Name;
            await _dbClient.ExecuteAsync($"""
                DROP TABLE IF EXISTS {tableName};
                """);
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }


        public Task GetAll(int start, int length)
        {
            throw new NotImplementedException();
        }

        public Task GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(T data)
        {
            throw new NotImplementedException();
        }

        public Task Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
