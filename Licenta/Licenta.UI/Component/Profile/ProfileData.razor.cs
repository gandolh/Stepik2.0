using Licenta.SDK.Models;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Profile
{
    public partial class ProfileData
    {
        [Parameter] public PortalUserDto User { get; set; } = default!;
        [Parameter] public EventCallback<PortalUserDto> UserChanged { get; set; } = default!;
        [Parameter] public bool Disabled { get; set; }

        public string DisplayableRoles = string.Empty;


        protected override Task OnParametersSetAsync()
        {
            DisplayableRoles = string.Join(", ", User.Roles.Select(el => GetNameOf(el)));
            return base.OnParametersSetAsync();
        }

        private string GetNameOf(RoleType roleType)
        {
            return roleType switch
            {
                RoleType.Guest => "Guest",
                RoleType.Student => "Student",
                RoleType.Teacher => "Teacher",
                RoleType.Admin => "Admin",
                _ => "",
            };
        }
    }
}
