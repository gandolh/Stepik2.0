using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class ModuleService
    {
        private readonly ModuleRepository _repository;
        private readonly ModuleMapper _mapper;

        public ModuleService(ModuleRepository repository)
        {
            _repository = repository;
            _mapper = new ModuleMapper();
        }

        internal async Task<IEnumerable<ModuleDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }

        internal async Task<ModuleDto> GetOne(int id)
        {
            return _mapper.Map(await _repository.GetOneAsync(id));
        }

        internal async Task<UpdateResult> Update(ModuleDto c)
        {
            await _repository.UpdateAsync(_mapper.Map(c));
            return new(typeof(ModuleDto), c.Id);
        }
    }
}
