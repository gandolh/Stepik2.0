using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice
{
    public partial class ExercisePage : BaseCrudPage
    {
        public ExerciseDto NewDto { get; set; } = new ExerciseDto();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadDatatable();

            }

            await base.OnAfterRenderAsync(firstRender);
        }

        protected override async Task HandleRemove(int selectedId)
        {
            await httpLicentaClient.DeleteExercise(selectedId);
            await LoadDatatable();
        }

        private async Task HandleCreate()
        {
            await httpLicentaClient.CreateExercise(NewDto);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            var elts = await httpLicentaClient.GetExercises();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);
            var dotnetRef = DotNetObjectReference.Create(this);

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId, ModalUpdateId, dotnetRef);
        }

        private void HandleUpdate()
        {

        }

        protected override Task HandleSelectedIdChanged(int selectedId)
        {
            throw new NotImplementedException();
        }
    }
}
