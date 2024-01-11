using static Dapper.SqlMapper;

namespace Licenta.Db.Seeder.Interfaces
{
    public interface IDapperDbClient : IDbClient
    {
        void CommitTransaction();
        Task<List<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "id");

        Task<GridReader> QueryMultipleAsync(string sql, object param = null);
    }
}
