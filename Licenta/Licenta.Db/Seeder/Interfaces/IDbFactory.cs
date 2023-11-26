using System.Data;

namespace Licenta.Db.Seeder.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        IDbConnection Context();
    }
}
