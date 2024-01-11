using Dapper;
using Licenta.Db.Seeder.Interfaces;
using System.Data;
using static Dapper.SqlMapper;

namespace Licenta.Db.Seeder
{
    public class DapperDbClient : IDapperDbClient
    {
        protected readonly IDbFactory dbFactory;

        protected IDbTransaction dbTransaction;

        public DapperDbClient(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
            dbTransaction = dbFactory.Context().BeginTransaction();
        }

        public void Dispose()
        {
            dbFactory.Dispose();
            dbTransaction.Dispose();
        }

        public async Task<List<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "id")
        {
            return (await dbFactory.Context().QueryAsync(sql, map, param: param, transaction: dbTransaction, splitOn: splitOn)).ToList();
        }

        public async Task<List<TReturn>> QueryAsync<TReturn>(string sql, object param = null)
        {
            return (await dbFactory.Context().QueryAsync<TReturn>(sql, param, dbTransaction)).ToList();
        }

        public async Task<GridReader> QueryMultipleAsync(string sql, object param = null)
        {
            return await dbFactory.Context().QueryMultipleAsync(sql, param, dbTransaction);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await dbFactory.Context().ExecuteAsync(sql, param, dbTransaction);
        }

        public async Task<TReturn> QueryFirstOrDefaultAsync<TReturn>(string sql, object param = null)
        {
            return await dbFactory.Context().QueryFirstOrDefaultAsync<TReturn>(sql, param, dbTransaction);
        }

        public async Task<TReturn> ExecuteScalarAsync<TReturn>(string sql, object param = null)
        {
            return await dbFactory.Context().ExecuteScalarAsync<TReturn>(sql, param, dbTransaction);
        }

        public void CommitTransaction()
        {
            dbTransaction.Commit();
            dbTransaction = dbFactory.Context().BeginTransaction();
        }

   
    }
}
