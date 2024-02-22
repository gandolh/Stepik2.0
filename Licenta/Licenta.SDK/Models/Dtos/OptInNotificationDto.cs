namespace Licenta.SDK.Models.Dtos
{
    public class OptInNotificationDto
    {
        public int Id { get; set; }
        public bool WhenAccountChanges { get; set; } = true;
        public bool WhenNewProducts { get; set; } = false;
        public bool WhenMarketingAndPromo { get; set; } = false;
        public bool WhenSecurityAlerts { get; set; } = true;  
    }
}
