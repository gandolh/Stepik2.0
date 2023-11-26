using Components.UI;
using Components.UI.Enums;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Index
{
    public partial class CourseList : BaseLicentaComp<ComponentResource>
    {
        [Inject] IApiService apiService { get; set; } = default!;
        private List<CourseDto> _courses = new List<CourseDto>();

        protected override async Task OnInitializedAsync()
        {
            pageState = PageState.Loading;
            _courses = (await apiService.GetCourses()).ToList();
            pageState = PageState.Success;
            await base.OnInitializedAsync();
        }

    }
}


