using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Form
{
    public partial class Label
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string ElementId { get; set; } = "";
        [Parameter] public string For { get; set; } = "";
        [Parameter] public int MarginBottom { get; set; } = 2;
    }
}
