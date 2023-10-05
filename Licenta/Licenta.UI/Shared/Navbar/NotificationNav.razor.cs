using Components.UI.Enums;
using Licenta.Sdk.Models.Data;

namespace Licenta.UI.Shared.Navbar
{
    public partial class NotificationNav
    {
        //[Inject] private IUserClient _userClient { get; set; } = default!;

        public List<Notification> Notifications { get; set; } = new List<Notification>();

        protected override async Task OnInitializedAsync()
        {
            pageState = PageState.Loading;
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //dont block the UI render
                try
                {
                    //Notifications = await _userClient.GetNotificationsAsync();
                    pageState = PageState.Loaded;

                }
                catch (Exception ex)
                {
                    pageState = PageState.Error;
                }
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
