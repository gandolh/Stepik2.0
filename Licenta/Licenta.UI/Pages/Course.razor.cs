using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Pages
{
    public partial class Course
    {
        [Parameter] public string CourseId { get; set; } = "";
        [Inject] public IApiService apiService { get; set; } = default!;
        private CourseDto? _course;

        protected override Task OnInitializedAsync()
        {
            _course = apiService.GetCourse(CourseId);
            return base.OnInitializedAsync();
        }
    }
}
