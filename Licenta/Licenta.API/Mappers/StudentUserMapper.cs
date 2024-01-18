using Licenta.Db.Data;
using Licenta.Db.DataModel;

namespace Licenta.API.Mappers
{
    public class StudentUserMapper : BaseMapper<Student, User>
    {
        public override Student Map(User element)
        {
            return new Student()
            {
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email,
                Password = element.Password
            };
        }

        public override User Map(Student element)
        {
            return new User()
            {
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email,
                Password = element.Password
            };
        }
    }
}
