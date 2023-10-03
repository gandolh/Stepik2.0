using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Others
{
    public partial class ListGroup
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;

        [Parameter] public string Class { get; set; } = "";
        [Parameter] public bool Numbered { get; set; } = false;
    }
}
