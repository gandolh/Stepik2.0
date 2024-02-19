using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class ModuleService : BaseCrudService<Module, ModuleDto, ModuleDto>
    {
        public ModuleService(ModuleRepository repository) : base(repository, new ModuleMapper(), new ModuleMapper())
        {
        }
    }
}
