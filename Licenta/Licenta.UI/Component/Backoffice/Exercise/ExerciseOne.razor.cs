using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Exercise
{
    public partial class ExerciseOne : BaseShowOne
    {
        [Parameter] public ExerciseDto? dto { get; set; }
        [Parameter] public EventCallback<ExerciseDto?> DtoChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (IsNew == false)
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
