using Components.UI;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.Lesson
{
    public partial class LessonOne : BaseShowOne
    {
        [Parameter] public FullLessonDto? dto { get; set; }
        [Parameter] public EventCallback<FullLessonDto?> DtoChanged { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; } = default!;

        private const string BodyRichEditorId = "lessonBodyEditor";
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

            await JsRuntime.InvokeVoidAsync("MaterializeInitializer.initRichTextEditor", BodyRichEditorId);

            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateLesson(dto);
        }
    }
}
