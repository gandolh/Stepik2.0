using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Stepper
{
    public partial class StepPanel
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}