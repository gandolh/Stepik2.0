using Components.UI;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Pages
{
    public partial class Courses : BaseLicentaComp
    {
        [Inject] public HttpLicentaClient httpLicentaClient { get; set; } = default!;
        private List<CourseDto> _courses = new();


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender) {
                _courses = await httpLicentaClient.GetCourses(User.Email);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);    
        }
    }
}
