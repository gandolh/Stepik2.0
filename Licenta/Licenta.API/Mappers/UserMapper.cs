using Licenta.Db.DataModel;
using Licenta.SDK.Models;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class UserMapper : BaseMapper<PortalUser, PortalUserDto>
    {
        public override PortalUser Map(PortalUserDto element)
        {
            return new PortalUser()
            {   Id = element.Id,
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email,
                Roles = element.Roles.Select(el => (int)el).ToList()
            };
        }

        public override PortalUserDto Map(PortalUser element)
        {
            return new PortalUserDto()
            {
                Id = element.Id,
                Firstname = element.Firstname,
                Lastname = element.Lastname,
                Email = element.Email,
                Roles = element.Roles.Select(el => (RoleType)el).ToList()
            };
        }
    }
}
