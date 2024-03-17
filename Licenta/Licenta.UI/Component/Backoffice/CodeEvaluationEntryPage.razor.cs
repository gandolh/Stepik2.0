using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Licenta.UI.Data;
using Microsoft.JSInterop;
using System.Security.Cryptography.Xml;

namespace Licenta.UI.Component.Backoffice
{
    public partial class CodeEvaluationEntryPage : BaseCrudPage
    {
        public CodeEvaluationEntryDto NewDto { get; set; } = new CodeEvaluationEntryDto();
        public CodeEvaluationEntryDto? UpdateDto { get; set; }
        public List<ExerciseDto> exerciseDtos { get; set; } = new List<ExerciseDto>();
        public List<FullCodeEvaluationEntryDto> CodeEvalDtos { get; set; } = new List<FullCodeEvaluationEntryDto>();

        private const string deleteModalTitle = "Delete code evaluation";
        private const string createModalTitle = "Create code evaluation";
        private const string updateModalTitle = "Update code evaluation";

        protected override async Task OnInitializedAsync()
        {
            exerciseDtos = await httpLicentaClient.GetExercises();
            await base.OnInitializedAsync();
        }

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
            CodeEvalDtos = await httpLicentaClient.GetFullCodeEvaluations();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(CodeEvalDtos);

            var dotnetRef = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId, ModalUpdateId, dotnetRef);

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


        private async Task HandleUpdate()
        {
            await httpLicentaClient.UpdateCodeEvaluation(UpdateDto);
        }

        protected override Task HandleSelectedIdChanged(int selectedId)
        {
            UpdateDto = CodeEvalDtos.Find(el => el.Id == selectedId);
            return Task.CompletedTask;
        }
    }
}
