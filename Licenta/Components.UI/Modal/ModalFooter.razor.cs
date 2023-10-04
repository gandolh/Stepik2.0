using Microsoft.AspNetCore.Components;

namespace Components.UI.Modal
{
    public partial class ModalFooter
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;

    }
}