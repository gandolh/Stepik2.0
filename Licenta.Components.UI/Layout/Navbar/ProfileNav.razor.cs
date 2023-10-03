using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Layout.Navbar
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
