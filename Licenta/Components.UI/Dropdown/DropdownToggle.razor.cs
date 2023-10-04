using Microsoft.AspNetCore.Components;

namespace Components.UI.Dropdown
{
    public partial class DropdownToggle
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string ElementId { get; set; } = "";
    }
}
