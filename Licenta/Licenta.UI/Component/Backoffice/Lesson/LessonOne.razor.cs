using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Lesson
{
    public partial class LessonOne : BaseShowOne
    {
        [Parameter] public LessonDto? dto { get; set; }
        [Parameter] public EventCallback<LessonDto?> DtoChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (IsNew == false)
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
