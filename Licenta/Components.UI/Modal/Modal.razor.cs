using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Components.UI.Modal
{
    public partial class Modal
    {
        [Parameter] public string ModalId { get; set; } = "modal-1";
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public RenderFragment Body { get; set; } = default!;
        [Parameter] public RenderFragment Footer { get; set; } = default!;

        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitModal");
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
