using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Backoffice
{
    public partial class ModalOneLayout
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string ModalTitle { get; set; } = default!;
        [Parameter] public string ModalId { get; set; } = default!;

    }
}
