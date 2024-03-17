using Components.UI;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Form
{
    public partial class ExerciseForm : BaseShowOne
    {
        [Parameter] public ExerciseDto? dto { get; set; }
        [Parameter] public EventCallback<ExerciseDto?> DtoChanged { get; set; }
        private AutoCompleteData _autoCompleteData = new();

        protected override async Task OnInitializedAsync()
        {
            var modules = await HttpLicentaClient.GetModules();
            foreach (var module in modules)
                _autoCompleteData.Add(module.Name, "");
            await base.OnInitializedAsync();
        }

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
