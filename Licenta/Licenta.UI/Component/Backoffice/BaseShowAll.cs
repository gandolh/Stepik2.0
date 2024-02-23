using Components.UI;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice
{
    public abstract class BaseShowAll : BaseLicentaComp, IAsyncDisposable
    {
        protected const string EltId = "example";
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected HttpLicentaClient httpLicentaClient { get; set; } = default!;
        protected string _modalRemoveId = "modal-show-all-remove";
        protected string _modalCreateId = "modal-show-all-create";

        protected abstract Task HandleRemove(int selectedId);

        protected async Task HandleRemove()
        {
            await JSRuntime.InvokeVoidAsync($"Main.ModalClose", _modalRemoveId);
            string id = await JSRuntime.InvokeAsync<string>("Main.GetSelectedId", _modalRemoveId);
            await HandleRemove(Int32.Parse(id));
            await JSRuntime.InvokeVoidAsync("Main.showToast", "entitate ștearsă", "success");
        }

        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.DestroyDataTable", EltId);
        }
    }
}
