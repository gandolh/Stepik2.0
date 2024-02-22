using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Profile
{
    public partial class EditProfileData
    {
        [Parameter] public PortalUserDto User { get; set; } = default!;
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;

        public async void HandleSave()
        {
            await HttpLicentaClient.UpdatePortalUser(User);
        }
    }
}
