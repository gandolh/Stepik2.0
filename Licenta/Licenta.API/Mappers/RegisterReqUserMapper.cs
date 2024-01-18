using Licenta.Db.Data;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class RegisterReqUserMapper : BaseMapper<RegisterReqDto, User>
    {
        public override RegisterReqDto Map(User element)
        {
            return new RegisterReqDto()
            {
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email,
                Password = element.Password
            };
        }

        public override User Map(RegisterReqDto element)
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
