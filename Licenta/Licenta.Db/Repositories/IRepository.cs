namespace Licenta.Db.Repositories
{
    public interface IRepository<T> 
    {
        public Task GetOneAsync(string id);
        public Task<List<T>> GetAllAsync(int start, int length);
        public Task InsertAsync(T data);
        public Task UpdateAsync(T data);
        public Task DeleteAsync(string id);
        public Task CreateTableAsync();
        public Task DropTableAsync();
    }
}
