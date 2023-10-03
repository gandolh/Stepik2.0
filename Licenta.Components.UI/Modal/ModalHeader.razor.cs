using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Modal
{
    public partial class ModalHeader
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
    }
}