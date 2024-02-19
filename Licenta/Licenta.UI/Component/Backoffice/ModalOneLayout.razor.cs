using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Data;

namespace Licenta.UI.Component.Backoffice
{
    public partial class ModalOneLayout
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string ModalTitle { get; set; } = default!;
        [Parameter] public string ModalId { get; set; } = default!;
        [Parameter] public EventCallback<int> OnRemove { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; } = default!;

        private async Task HandleRemove()
        {
            await JsRuntime.InvokeVoidAsync($"Main.ModalClose", ModalId);
            string id = await JsRuntime.InvokeAsync<string>("Main.GetSelectedId", ModalId);
            await OnRemove.InvokeAsync(Int32.Parse(id));
            await JsRuntime.InvokeVoidAsync("Main.showToast", "entitate ștearsă", "success");
        }

    }
}
