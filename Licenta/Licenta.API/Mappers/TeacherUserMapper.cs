using Licenta.Db.Data;
using Licenta.Db.DataModel;

namespace Licenta.API.Mappers
{
    public class TeacherUserMapper : BaseMapper<Teacher, User>
    {
        public override Teacher Map(User element)
        {
            return new Teacher()
            {
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email,
                Password = element.Password
            };
        }

        public override User Map(Teacher element)
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
