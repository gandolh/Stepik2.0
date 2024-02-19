using Components.UI;
using Components.UI.Enums;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Home
{
    public partial class MainGrid : BaseLicentaComp
    {
        private List<CourseDto> _courses = new();
        [Inject] public HttpLicentaClient httpLicentaClient { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            pageState = PageState.Loading;
            _courses = await httpLicentaClient.GetCourses(User.Email);

            pageState = PageState.Loaded;
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
