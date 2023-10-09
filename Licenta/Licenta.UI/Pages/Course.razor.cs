using Licenta.Sdk.Models.Data;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Pages
{
    public partial class Course
    {
        [Parameter] public string CourseId { get; set; } = "";

        private Sdk.Models.Data.Course? _course;

        protected override Task OnInitializedAsync()
        {
            _course = SampleData.GetCourses().FirstOrDefault((el)=> el.Id == CourseId);
            return base.OnInitializedAsync();
        }
    }
}
