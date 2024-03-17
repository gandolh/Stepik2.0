using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Form
{
    public partial class CourseForm : BaseShowOne
    {
        [Parameter] public CourseDto? Dto { get; set; }
        [Parameter] public EventCallback<CourseDto?> DtoChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (IsNew == false)
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
