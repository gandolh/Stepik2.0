using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Layout
{
    public partial class ProfileCard
    {
        [Parameter] public string Fullname { get;set; } = string.Empty;
        [Parameter] public string Email { get;set; } = string.Empty;
    }
}
