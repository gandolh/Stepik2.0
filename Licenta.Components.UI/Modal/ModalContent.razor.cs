using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Modal
{
    public partial class ModalContent
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";


    }
}