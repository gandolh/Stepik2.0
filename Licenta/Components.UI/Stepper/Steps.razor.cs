using Microsoft.AspNetCore.Components;

namespace Components.UI.Stepper
{
    public partial class Steps
    {
        [Parameter] public RenderFragment Items { get; set; } = default!;
        [Parameter] public RenderFragment Content { get; set; } = default!;

    }
}