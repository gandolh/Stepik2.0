using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice
{
    public partial class CodeEvaluationEntryPage : BaseCrudPage
    {
        public string ModalUpdateId { get; set; } = "ModalUpdateId";

        public CodeEvaluationEntryDto NewDto { get; set; } = new CodeEvaluationEntryDto();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
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

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId, ModalUpdateId);
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

        private void HandleUpdate()
        {

        }
    }
}
