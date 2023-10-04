using Microsoft.AspNetCore.Components;

namespace Components.UI.Dropdown
{
    public partial class Dropdown
    {
        //parameter ChildContent of type RenderFragment
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string ElementId { get; set; } = "";
        [Parameter] public string Class { get; set; } = "";

    }
}
