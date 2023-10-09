using Components.UI;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Data;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Courses
{
    public partial class CoursesList : BaseLicentaComp<ComponentResource>
    {
        [Inject] public NavigationManager navManager { get; set; } = default!;
        private Course[] courses = SampleData.GetCourses();

        private void RedirectToCourse(Course course)
        {
            navManager.NavigateTo($"course/{course.Id}");
        }
    }
}
