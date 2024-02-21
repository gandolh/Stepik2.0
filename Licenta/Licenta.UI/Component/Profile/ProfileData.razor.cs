using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Profile
{
    public partial class ProfileData
    {
        [Parameter] public PortalUserDto User { get; set; } = default!;
        [Parameter] public bool Disabled { get; set; }
    }
}
