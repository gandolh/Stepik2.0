using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class ModuleService : BaseCrudService<Module, ModuleDto>
    {
        public ModuleService(ModuleRepository repository) : base(repository, new ModuleMapper())
        {
        }
    }
}
