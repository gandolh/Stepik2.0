using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.CodeEval
{
    public partial class CodeEvalAll : BaseShowAll
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await LoadDatatable();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task LoadDatatable()
        {
            // DESTROY AND REMAKE TABLE
            var elts = await httpLicentaClient.GetCodeEvaluations();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId);
        }

        private async Task HandleRemove(int selectedId)
        {
            await httpLicentaClient.DeleteCodeEvaluation(selectedId);
            await LoadDatatable();
        }



    }
}
