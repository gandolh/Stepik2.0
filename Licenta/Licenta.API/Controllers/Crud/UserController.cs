using Licenta.API.Models;
using Licenta.API.Services.Crud;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography.Xml;

namespace Licenta.API.Controllers.Crud
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController :BaseCrudController<PortalUser, PortalUserDto, PortalUserDto>
    {
        public UserController(UserService service) : base(service)
        {
        }

        [SwaggerOperation(Summary = "Get all portal users", Description = "")]
        public override async Task<IEnumerable<PortalUserDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get portal user by Id", Description = "")]
        public override async Task<ActionResult<PortalUserDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full portal user all", Description = "")]
        public override async Task<IEnumerable<PortalUserDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full portal user by Id", Description = "")]
        public override async Task<ActionResult<PortalUserDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update portal user", Description = "")]
        public override async Task<UpdateResult> Update(PortalUserDto c)
        {
            return await base.Update(c);
        }
        [SwaggerOperation(Summary = "Delete portal user", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all portal users that are teachers", Description = "")]
        public async Task<IEnumerable<PortalUserDto>> GetAllTeachers()
        {
            return (await _service.GetAll()).Where(el => el.Roles.Any(role => role == SDK.Models.RoleType.Teacher)).ToList();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all portal users that are students", Description = "")]
        public  async Task<IEnumerable<PortalUserDto>> GetAllStudents()
        {
            return (await _service.GetAll()).Where(el => el.Roles.Any(role => role == SDK.Models.RoleType.Student)).ToList();

        }
    }
}
