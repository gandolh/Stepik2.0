using Npgsql;

namespace Licenta.Db.Repository
{
    public interface IRepository
    {
        public void CreateTableIfNotExists();
        public void SeedIfEmpty();
    }
}
