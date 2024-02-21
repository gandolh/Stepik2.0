using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Profile
{
    public partial class OverviewProfileData
    {
        [Parameter] public PortalUserDto User { get; set; } = default!;

    }
}
