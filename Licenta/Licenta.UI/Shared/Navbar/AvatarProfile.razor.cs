using Licenta.Sdk.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Licenta.UI.Shared.Navbar
{
    public partial class AvatarProfile
    {
        [CascadingParameter] private Task<AuthenticationState>? authenticationState { get; set; }
        public ClaimsPrincipal? User { get; set; }
        private string _firstInitial => !(User?.Identity?.IsAuthenticated ?? false) ? "" : ClaimHelper.GetFirstName(User)?.First().ToString() ?? "";
        private string _lastName => !(User?.Identity?.IsAuthenticated ?? false) ? "" : ClaimHelper.GetLastName(User) ?? "";
        private string _fullName => !(User?.Identity?.IsAuthenticated ?? false) ? "" : ClaimHelper.GetFullName(User);
        private string _email => !(User?.Identity?.IsAuthenticated ?? false) ? "" : ClaimHelper.GetEmail(User);

        protected override async Task OnInitializedAsync()
        {
            User = await GetUser();
            await base.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {

            return base.OnAfterRenderAsync(firstRender);
        }


        private async Task<ClaimsPrincipal?> GetUser()
        {
            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                var user = authState?.User;
                return user;
            }
            return null;
        }
    }
}
