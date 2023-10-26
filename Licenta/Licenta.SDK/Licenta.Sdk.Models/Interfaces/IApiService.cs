using Licenta.Sdk.Models.Dtos;

namespace Licenta.Sdk.Models.Interfaces
{
    public interface IApiService
    {
        public IEnumerable<CourseDto> GetCourses();
        public CourseDto? GetCourse(string courseId);
        IEnumerable<EventDto> GetEvents(DateTime? after = null);
        IEnumerable<LastAccesedDto> GetAccesedLessons();
    }
}
