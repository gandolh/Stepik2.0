using Microsoft.AspNetCore.Components;

namespace Components.UI.Card
{
    public partial class Card
    {
        //parameter ChildContent
        [Parameter] public RenderFragment CardBody { get; set; } = default!;
        [Parameter] public RenderFragment CardFooter { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
    }
}
