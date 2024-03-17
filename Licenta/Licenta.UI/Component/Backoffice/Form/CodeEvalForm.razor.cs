using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Form
{
    public partial class CodeEvalForm : BaseShowOne
    {
        [Parameter] public CodeEvaluationEntryDto dto { get; set; } = default!;
        [Parameter] public EventCallback<CodeEvaluationEntryDto?> DtoChanged { get; set; }
        [Parameter][EditorRequired] public List<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        private void HandleChangeExerciseId(ChangeEventArgs e)
        {
            dto!.ExerciseId =  int.Parse(e.Value!.ToString()!);
        }




    }
}
