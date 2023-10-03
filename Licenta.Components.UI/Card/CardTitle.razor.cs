using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Card
{
    public partial class CardTitle
    {
        // parameter ChildContent of type RenderFragment
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        // parameter Class of type string
        [Parameter] public string Class { get; set; } = "";
    }
}
