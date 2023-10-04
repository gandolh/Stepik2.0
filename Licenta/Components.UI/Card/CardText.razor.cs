using Microsoft.AspNetCore.Components;

namespace Components.UI.Card
{
    public partial class CardText
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
    }
}
