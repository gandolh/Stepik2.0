using Microsoft.AspNetCore.Components;

namespace Components.UI.Modal
{
    public partial class ModalHeader
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
    }
}