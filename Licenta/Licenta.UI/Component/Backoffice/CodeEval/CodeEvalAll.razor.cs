using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.CodeEval
{
    public partial class CodeEvalAll : BaseShowAll
    {
        public CodeEvaluationEntryDto NewDto { get; set; } = new CodeEvaluationEntryDto();
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
            var elts = await httpLicentaClient.GetFullCodeEvaluations();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId);
        }

        protected override async Task HandleRemove(int selectedId)
        {
            await httpLicentaClient.DeleteCodeEvaluation(selectedId);
            await LoadDatatable();
        }

        private async Task HandleCreate()
        {
            await httpLicentaClient.CreateCodeEvaluationEntry(NewDto);
            await LoadDatatable();
        }



    }
}
