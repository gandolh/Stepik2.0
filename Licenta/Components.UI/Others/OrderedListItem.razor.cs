using Microsoft.AspNetCore.Components;

namespace Components.UI.Others
{
    public partial class OrderedListItem
    {
        //parameter ChildContent of type RenderFragment
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        //parameter Class of type string
        [Parameter] public string Class { get; set; } = "";

    }
}
