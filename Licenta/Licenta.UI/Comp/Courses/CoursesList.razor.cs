using Components.UI;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Courses
{
    public partial class CoursesList : BaseLicentaComp<ComponentResource>
    {
        [Inject] public NavigationManager navManager { get; set; } = default!;
        [Inject] public IApiService apiService { get; set; } = default!;
        private CourseDto[] courses;

        protected override Task OnInitializedAsync()
        {
            courses = apiService.GetCourses();
            return base.OnInitializedAsync();
        }

        private void RedirectToCourse(CourseDto course)
        {
            navManager.NavigateTo($"course/{course.Id}");
        }
    }
}
