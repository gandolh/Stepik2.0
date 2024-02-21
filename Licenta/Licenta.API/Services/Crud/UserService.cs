using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class UserService : BaseCrudService<PortalUser, PortalUserDto, PortalUserDto>
    {
        public UserService(UserRepository repository) 
            : base(repository, new UserMapper(), new UserMapper())
        {
        }

        internal override async Task<IEnumerable<PortalUserDto>> GetFullAll()
        {
          return  await base.GetAll();
        }

        internal override async Task<PortalUserDto?> GetFullOne(int id)
        {
            return await base.GetOne(id);
        }
    }
}
