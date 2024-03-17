using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Data;

namespace Licenta.UI.Component.Backoffice.Layout
{
    public partial class ModalOneLayout
    {
        [Parameter] public RenderFragment Body { get; set; } = default!;
        [Parameter] public RenderFragment Footer { get; set; } = default!;
        [Parameter] public string ModalTitle { get; set; } = default!;
        [Parameter] public string ModalId { get; set; } = default!;
        [Parameter] public EventCallback<int> OnRemove { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; } = default!;



    }
}
