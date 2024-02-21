using Components.UI;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Pages
{
    public partial class Courses : BaseLicentaComp
    {
        [Inject] public HttpLicentaClient httpLicentaClient { get; set; } = default!;
        private List<FullCourseDto> _courses = new();


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender) {
                _courses = await httpLicentaClient.GetFullCourses();
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);    
        }

        private string[] GetDescription(CourseDto courseDto)
        {
            string teachers = "Profesori: " + string.Join(",",
                courseDto.Teachers.Select(el => $"{el.Firstname} {el.Lastname}"));

            int studentsTake = courseDto.Students.Count() > 5 ? 5 : courseDto.Students.Count();
            string students = "Studenti: " + string.Join(",",
                courseDto.Students.Select(el => $"{el.Firstname} {el.Lastname}" ));
            return [teachers, students];
        }
    }
}
