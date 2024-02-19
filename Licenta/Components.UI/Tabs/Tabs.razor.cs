using Microsoft.AspNetCore.Components;

namespace Components.UI.Tabs
{
    public partial class Tabs
    {
       [Parameter] public RenderFragment CurrentTabs { get; set; } = default!;
       [Parameter] public RenderFragment Content { get; set; } = default!;
    }
}
