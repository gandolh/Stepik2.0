using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.Exercise
{
    public partial class ExerciseAll : BaseShowAll
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

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId);
        }
    }
}
