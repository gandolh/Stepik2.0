using Microsoft.AspNetCore.Components;

namespace Components.UI.Others
{
    public partial class OrderedList
    {
        //parameter ChildContent of type RenderFragment
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;

    }
}
