namespace Licenta.Db.DataModel
{
    public class OptInNotification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool WhenAccountChanges { get; set; } = true;
        public bool WhenNewProducts { get; set; } = false;
        public bool WhenMarketingAndPromo { get; set; } = false;
        public bool WhenSecurityAlerts { get; set; } = true;

        public OptInNotification()
        {
            
        }

        public OptInNotification(int userId)
        {
            UserId = userId;
        }

        public OptInNotification(int id, int userId, bool whenAccountChanges, bool whenNewProducts, bool whenMarketingAndPromo, bool whenSecurityAlerts)
        {
            Id = id;
            UserId = userId;
            WhenAccountChanges = whenAccountChanges;
            WhenNewProducts = whenNewProducts;
            WhenMarketingAndPromo = whenMarketingAndPromo;
            WhenSecurityAlerts = whenSecurityAlerts;
        }
    }
}
