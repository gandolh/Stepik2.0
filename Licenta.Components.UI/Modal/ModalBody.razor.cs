using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Modal
{
    public partial class ModalBody
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
    }
}