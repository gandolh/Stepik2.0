using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Shared.Navbar
{
    public partial class ProfileNav
    {
        [Inject] NavigationManager NavManager { get; set; }
        private void Login()
        {
            NavManager.NavigateTo($"login?redirectUri={NavManager.Uri}", true);
        }

    }
}
