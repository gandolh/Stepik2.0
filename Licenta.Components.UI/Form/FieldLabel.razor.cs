using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Form
{
    public partial class FieldLabel
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string For { get; set; } = "";

    }
}
