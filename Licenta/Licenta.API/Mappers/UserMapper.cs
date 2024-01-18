using Licenta.Db.Data;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class UserMapper : BaseMapper<User, UserDto>
    {
        public override User Map(UserDto element)
        {
            return new User()
            {
                Firstname = element.Firstname,
                Lastname = element.Lastname,
            Email = element.Email
            };
        }

        public override UserDto Map(User element)
        {
            return new UserDto()
            {
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email
            };
        }
    }
}
