using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Component.Backoffice.Exercise
{
    public partial class ExerciseOne : BaseShowOne
    {
        public ExerciseDto? dto { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dto = await HttpLicentaClient.GetOneExercise(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateExercise(dto);
        }
    }
}
