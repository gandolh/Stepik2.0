using Components.UI;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Form
{
    public partial class LessonForm : BaseShowOne
    {
        [Parameter] public FullLessonDto? dto { get; set; }
        [Parameter] public EventCallback<FullLessonDto?> DtoChanged { get; set; }
        private AutoCompleteData _autoCompleteData = new();

        protected override async Task OnInitializedAsync()
        {
            var lessons = await HttpLicentaClient.GetLessons();
            foreach (var lesson in lessons)
                _autoCompleteData.Add(lesson.Name, "");
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (IsNew == false)
                    dto = await HttpLicentaClient.GetFullOneLesson(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateLesson(dto);
        }
    }
}
