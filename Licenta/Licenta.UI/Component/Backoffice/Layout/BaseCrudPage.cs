using Components.UI;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.Layout
{
    public abstract class BaseCrudPage : BaseLicentaComp
    {
        [Parameter] public string ViewMode { get; set; } = string.Empty;
        [Parameter] public int? Id { get; set; }


        protected const string EltId = "example";
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected HttpLicentaClient httpLicentaClient { get; set; } = default!;
        protected const string _modalRemoveId = "modal-show-all-remove";
        protected const string _modalCreateId = "modal-show-all-create";
        protected const string ModalUpdateId = "modal-update-entity";
        protected int SelectedId = -1;

        protected abstract Task HandleRemove(int selectedId);
        protected abstract Task HandleSelectedIdChanged(int selectedId);

        protected async Task HandleRemove()
        {
            await JSRuntime.InvokeVoidAsync($"Main.ModalClose", _modalRemoveId);
     
            await HandleRemove(SelectedId);
            await JSRuntime.InvokeVoidAsync("Main.showToast", "entitate ștearsă", "success");
        }

        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.DestroyDataTable", EltId);
        }

        [JSInvokable("SetSelectedId")]
        public void SetSelectedId(string value)
        {
            try
            {
                SelectedId = int.Parse(value);
                HandleSelectedIdChanged(SelectedId);
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
