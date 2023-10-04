using Microsoft.AspNetCore.Components;

namespace Components.UI.Modal
{
    public partial class ModalContent
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";


    }
}