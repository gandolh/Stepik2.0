using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Layout
{
    public partial class ErrorPopup
    {
        [Parameter] public bool IsDebug { get; set; } = false;
    }
}
