using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class Row
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
    }
}
