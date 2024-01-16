using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class CourseMapper : BaseMapper<Course, CourseDto>
    {
        public override Course Map(CourseDto element)
        {
            return new Course()
            {
                Id = element.Id,
                Name = element.Name
            };
        }

        public override CourseDto Map(Course element)
        {
            return new CourseDto()
            {
                Id = element.Id,
                Name = element.Name
            };
        }
    }
}
