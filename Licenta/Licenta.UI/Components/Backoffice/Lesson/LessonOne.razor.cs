using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Components.Backoffice.Lesson
{
    public partial class LessonOne : BaseShowOne
    {
        public LessonDto? dto { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dto = await HttpLicentaClient.GetOneLesson(Id);
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
