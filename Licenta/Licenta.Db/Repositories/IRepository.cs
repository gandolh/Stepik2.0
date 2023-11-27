namespace Licenta.Db.Repositories
{
    public interface IRepository<T> 
    {
        public Task GetOne(string id);
        public Task GetAll(int start, int length);
        public Task Insert(T data);
        public Task Update(T data);
        public Task Delete(string id);
        public Task CreateTable();
        public Task DropTable();
    }
}
