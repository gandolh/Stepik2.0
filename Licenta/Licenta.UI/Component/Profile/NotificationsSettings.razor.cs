using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Profile
{
    public partial class NotificationsSettings
    {
        private OptInNotificationDto _optInNotificationDto;
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;
        [Parameter] public int UserId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _optInNotificationDto = await HttpLicentaClient.GetOptInNotifications(UserId);
            await base.OnInitializedAsync();
        }

        public async Task HandleSave()
        {
            await HttpLicentaClient.UpdateOptInNotifications(_optInNotificationDto);
        }
    }
}
