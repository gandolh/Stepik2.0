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
        private CourseDto[] _courses = new CourseDto[0];

        protected override Task OnInitializedAsync()
        {
            pageState = PageState.Loading;
            _courses = apiService.GetCourses();
            pageState = PageState.Success;
            return base.OnInitializedAsync();
        }

    }
}


