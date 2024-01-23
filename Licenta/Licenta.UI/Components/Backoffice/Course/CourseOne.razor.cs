using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Components.Backoffice.Course
{
    public partial class CourseOne : BaseShowOne
    {
        public CourseDto? dto { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dto = await HttpLicentaClient.GetOneCourse(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
