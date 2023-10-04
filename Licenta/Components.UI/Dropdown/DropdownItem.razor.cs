using Microsoft.AspNetCore.Components;

namespace Components.UI.Dropdown
{
    public partial class DropdownItem
    {
        [Parameter] public string Href { get; set; } = "";
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string AnchorClass { get; set; } = "";
    }
}
