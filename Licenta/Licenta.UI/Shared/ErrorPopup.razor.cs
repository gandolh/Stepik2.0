using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Shared
{
    public partial class ErrorPopup
    {
        [Parameter] public bool IsDebug { get; set; } = false;
    }
}
