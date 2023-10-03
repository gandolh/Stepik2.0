using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Dropdown
{
    public partial class DropdownMenu
    {
        [Parameter] public RenderFragment HeaderContent { get; set; } = default!;
        [Parameter] public RenderFragment DropdownFooter { get; set; } = default!;
        [Parameter] public RenderFragment Items { get; set; } = default!;
        [Parameter] public string Class { get; set; } = default!;
        [Parameter] public string ElementId { get; set; } = "";

    }
}
