using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Backoffice.CodeEval
{
    public partial class CodeEvalAll : BaseShowAll
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await LoadDatatable();
                await JSRuntime.InvokeVoidAsync("MicroModal.init");
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task LoadDatatable()
        {
            // DESTROY AND REMAKE TABLE
            var elts = await httpLicentaClient.GetCodeEvaluations();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("Main.InitDataTable", EltId, json, _modalRemoveId);
        }

        private async Task HandleRemove(int selectedId)
        {
            await httpLicentaClient.DeleteCodeEvaluation(selectedId);
            await LoadDatatable();
        }



    }
}
