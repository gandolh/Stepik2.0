using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Profile
{
    public partial class EditProfileData
    {
        [Parameter] public UserDto User { get; set; } = default!;
    }
}
