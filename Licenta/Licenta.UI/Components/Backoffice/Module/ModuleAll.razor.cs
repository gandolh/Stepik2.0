using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Backoffice.Module
{
    public partial class ModuleAll : BaseShowAll
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadDatatable();
                await JSRuntime.InvokeVoidAsync("MicroModal.init");
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task HandleRemove(int selectedId)
        {
            await httpLicentaClient.DeleteModule(selectedId);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            var elts = await httpLicentaClient.GetModules();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("Main.InitDataTable", EltId, json, _modalRemoveId);
        }
    }
}
