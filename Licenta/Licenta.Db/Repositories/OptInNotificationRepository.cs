using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class OptInNotificationRepository : BaseRepository<OptInNotification>
    {
        public OptInNotificationRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }
        public override async Task CreateTableAsync()
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS OptInNotification (
                Id SERIAL PRIMARY KEY,
                UserId INT REFERENCES PortalUser(Id),
                WhenAccountChanges BOOLEAN,
                WhenNewProducts BOOLEAN,
                WhenMarketingAndPromo BOOLEAN,
                WhenSecurityAlerts BOOLEAN
            );
        ";
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(OptInNotification data)
        {
            string sql = @"
            INSERT INTO OptInNotification (UserId, WhenAccountChanges, WhenNewProducts, WhenMarketingAndPromo, WhenSecurityAlerts) 
            VALUES (@UserId, @WhenAccountChanges, @WhenNewProducts, @WhenMarketingAndPromo, @WhenSecurityAlerts);
        ";
            await _dbClient.ExecuteAsync(sql, data);
        }

        public override async Task UpdateAsync(OptInNotification data)
        {
            string sql = @"
            UPDATE OptInNotification SET 
            WhenAccountChanges = @WhenAccountChanges,
            WhenNewProducts = @WhenNewProducts,
            WhenMarketingAndPromo = @WhenMarketingAndPromo,
            WhenSecurityAlerts = @WhenSecurityAlerts
            WHERE Id = @Id;
        ";
            await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
