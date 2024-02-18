using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Profile
{
    public partial class OverviewProfileData
    {
        [Parameter] public UserDto User { get; set; } = default!;

    }
}
