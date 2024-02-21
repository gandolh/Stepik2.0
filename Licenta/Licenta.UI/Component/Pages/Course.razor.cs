using Components.UI;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Pages
{
    public partial class Course : BaseLicentaComp
    {
        [Parameter] public int Id { get; set; } = 0;
        [Inject] IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] HttpLicentaClient HttpLicentaClient { get; set; } = default!;

        private FullCourseDto _fullCourseDto = new FullCourseDto();
        private FullLessonDto? _activeLesson = null;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _fullCourseDto = await HttpLicentaClient.GetFullOneCourse(Id);
                 await JSRuntime.InvokeVoidAsync("MaterializeInitializer.initializeCollapsible");
                StateHasChanged();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private void HandleSelectLesson(FullLessonDto lesson)
        {
            _activeLesson = lesson;
        }
    }
}
