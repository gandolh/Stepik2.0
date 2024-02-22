using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class OptInNotificationMapper : BaseMapper<OptInNotification, OptInNotificationDto>
    {
        public override OptInNotification Map(OptInNotificationDto element)
        {
            return new OptInNotification()
            {
                Id= element.Id,
                WhenAccountChanges= element.WhenAccountChanges,
                WhenNewProducts= element.WhenNewProducts,
                WhenMarketingAndPromo= element.WhenMarketingAndPromo,
                WhenSecurityAlerts= element.WhenSecurityAlerts

            };
        }

        public override OptInNotificationDto Map(OptInNotification element)
        {
            return new OptInNotificationDto()
            {
                Id = element.Id,
                WhenAccountChanges = element.WhenAccountChanges,
                WhenNewProducts = element.WhenNewProducts,
                WhenMarketingAndPromo = element.WhenMarketingAndPromo,
                WhenSecurityAlerts = element.WhenSecurityAlerts

            };
        }
    }
}
