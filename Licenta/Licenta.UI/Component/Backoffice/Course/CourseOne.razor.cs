using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Course
{
    public partial class CourseOne : BaseShowOne
    {
        [Parameter] public CourseDto? Dto { get; set; }
        [Parameter] public EventCallback<CourseDto?> DtoChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if(IsNew == false)
                    Dto = await HttpLicentaClient.GetOneCourse(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateCourse(Dto);
        }
    }
}
