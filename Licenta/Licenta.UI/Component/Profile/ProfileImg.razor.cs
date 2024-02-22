using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Profile
{
    public partial class ProfileImg
    {
        [Parameter] public string Email { get; set; } = string.Empty;
        [Parameter] public string Class { get; set; } = string.Empty;
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;
        private const string defaultProfileSrc = "imgs/avatar-child-face.png";
        private string profileSrc = defaultProfileSrc;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                profileSrc = "data:image/png;base64, " + await HttpLicentaClient.GetProfilePicture(Email);
            }
            catch (Exception ex)
            {
            }
            await base.OnInitializedAsync();
        }
    }
}
