using Components.UI;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Module
{
    public partial class ModuleOne : BaseShowOne
    {
        [Parameter] public ModuleDto? dto { get; set; }
        [Parameter] public EventCallback<ModuleDto?> DtoChanged { get; set; }

        private AutoCompleteData _autoCompleteData = new();

        protected override async Task OnInitializedAsync()
        {
            var courses = await HttpLicentaClient.GetCourses();
            foreach (var course in courses)
                _autoCompleteData.Add(course.Name, "");
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (IsNew == false)
                    dto = await HttpLicentaClient.GetOneModule(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateModule(dto);
        }
    }
}
