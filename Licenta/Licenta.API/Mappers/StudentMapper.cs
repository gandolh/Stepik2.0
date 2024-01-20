using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class StudentMapper : BaseMapper<Student, StudentDto>
    {
        public override Student Map(StudentDto element)
        {
            return new Student()
            {
                Id = element.Id,
                Firstname = element.Firstname,
                Lastname = element.Lastname
            };
        }

        public override StudentDto Map(Student element)
        {
            return new StudentDto()
            {
                Id = element.Id,
                Firstname = element.Firstname,
                Lastname = element.Lastname
            };
        }
    }
}
