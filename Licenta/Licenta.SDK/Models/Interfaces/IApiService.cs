using Licenta.Sdk.Models.Dtos;

namespace Licenta.Sdk.Models.Interfaces
{
    public interface IApiService
    {
        public Task<IEnumerable<CourseDto>> GetCourses();
        public Task<CourseDto?> GetCourse(string courseId);
        public Task<IEnumerable<EventDto>> GetEvents(DateTime? after = null);
        public Task<IEnumerable<LastAccesedDto>> GetAccesedLessons(string userId);
    }
}
