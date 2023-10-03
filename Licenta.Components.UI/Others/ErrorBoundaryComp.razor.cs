using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Others
{
    public partial class ErrorBoundaryComp
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Label { get; set; } = "";
        [Parameter] public string Class { get; set; } = "w-100 h-100";
    }
}
