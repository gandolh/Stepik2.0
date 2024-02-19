using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public abstract class BaseCrudService<T, TDto> where TDto : IDtoWithId
    {
        protected readonly BaseRepository<T> _repository;
        protected readonly BaseMapper<T, TDto> _mapper;

        protected BaseCrudService(BaseRepository<T> repository, BaseMapper<T, TDto> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        internal virtual async Task<IEnumerable<TDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }

        internal virtual async Task<TDto> GetOne(int id)
        {
            return _mapper.Map(await _repository.GetOneAsync(id));
        }

        internal async Task<UpdateResult> Update(TDto c)
        {
            await _repository.UpdateAsync(_mapper.Map(c));
            return new(typeof(CodeEvaluationEntryDto), c.Id);
        }

        internal async Task<DeleteResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return new(typeof(TDto), id);
        }
    }
}
