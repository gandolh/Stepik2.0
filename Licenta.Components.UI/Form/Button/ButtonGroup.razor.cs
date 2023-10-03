using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Form.Button
{
    public partial class ButtonGroup
    {
        [Parameter] public RenderFragment Buttons { get; set; } = default!;

    }
}
