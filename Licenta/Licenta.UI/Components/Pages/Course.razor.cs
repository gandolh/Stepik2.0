using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StackExchange.Redis;

namespace Licenta.UI.Components.Pages
{
    public partial class Course
    {
        [Parameter] public int Id { get; set; } = 0;
        [Inject] IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] HttpLicentaClient HttpLicentaClient { get; set; } = default!;

        private FullCourseDto _fullCourseDto = new FullCourseDto();
        private LessonDto? _activeLesson = null;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _fullCourseDto = await HttpLicentaClient.GetOneCourse(Id);
                 await JSRuntime.InvokeVoidAsync("Main.initializeCollapsible");
                StateHasChanged();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private void HandleSelectLesson(LessonDto lesson)
        {
            _activeLesson = lesson;
        }
    }
}
