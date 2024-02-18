using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Profile
{
    public partial class EditProfileData
    {
        [Parameter] public UserDto User { get; set; } = default!;
    }
}
