using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class ModuleService : BaseCrudService<Module, ModuleDto, FullModuleDto>
    {
        public ModuleService(ModuleRepository repository) : base(repository, new ModuleMapper(), new FullModuleMapper())
        {
        }

        internal override async Task<IEnumerable<FullModuleDto>> GetFullAll()
        {
            return _fullMapper.Map(await _repository.GetAllAsync());
        }

        internal override async Task<FullModuleDto?> GetFullOne(int id)
        {
            var module = await ((ModuleRepository)_repository).GetFullOneAsync(id);
            if (module == null)
                return null;
            return _fullMapper.Map(module);
        }
    }
}
