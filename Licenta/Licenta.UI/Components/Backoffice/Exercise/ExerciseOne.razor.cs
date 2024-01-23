using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Components.Backoffice.Exercise
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
    }
}
