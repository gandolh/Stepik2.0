using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class TeacherMapper : BaseMapper<Teacher, TeacherDto>
    {
        public override Teacher Map(TeacherDto element)
        {
            return new Teacher()
            {
                Id = element.Id,
                Firstname = element.Firstname,
                Lastname = element.Lastname,
            };
        }

        public override TeacherDto Map(Teacher element)
        {
            return new TeacherDto()
            {
                Id = element.Id,
                Firstname = element.Firstname,
                Lastname = element.Lastname,
            };
        }
    }
}
