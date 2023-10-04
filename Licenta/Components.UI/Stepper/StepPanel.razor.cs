using Microsoft.AspNetCore.Components;

namespace Components.UI.Stepper
{
    public partial class StepPanel
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}