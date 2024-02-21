using Licenta.Db.Data;
using Licenta.Db.DataModel;
using Licenta.SDK.Models;
using Licenta.SDK.Models.Dtos;
using StackExchange.Redis;

namespace Licenta.API.Mappers
{
    public class RegisterReqUserMapper : BaseMapper<RegisterReqDto, PortalUser>
    {
        public override RegisterReqDto Map(PortalUser element)
        {
            return new RegisterReqDto()
            {
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email,
                Password = element.Password,
                IsStudent = element.Roles.Any(el => el == (int)RoleType.Student),
                IsTeacher = element.Roles.Any(el => el == (int)RoleType.Teacher),
            };
        }

        public override PortalUser Map(RegisterReqDto element)
        {
            var roles = new List<int>();
            if(element.IsStudent)
                roles.Add((int)RoleType.Student);
            if (element.IsTeacher)
                roles.Add((int)RoleType.Teacher);
            return new PortalUser()
            {
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email,
                Password = element.Password,
                Roles = roles,
            };
        }
    }
}
