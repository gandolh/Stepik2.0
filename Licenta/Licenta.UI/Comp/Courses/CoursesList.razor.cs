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
        private List<CourseDto> courses = new();

        protected override async Task OnInitializedAsync()
        {
            courses = (await apiService.GetCourses()).ToList();
            await base.OnInitializedAsync();
        }

        private void RedirectToCourse(CourseDto course)
        {
            navManager.NavigateTo($"course/{course.Id}");
        }
    }
}
