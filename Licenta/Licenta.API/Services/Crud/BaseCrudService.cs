﻿using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public abstract class BaseCrudService<T, TDto, TFullDto>
        where TDto : IDtoWithId
        where TFullDto : IDtoWithId
    {
        protected readonly BaseRepository<T> _repository;
        protected readonly BaseMapper<T, TDto> _mapper;
        protected readonly BaseMapper<T, TFullDto> _fullMapper;

        protected BaseCrudService(BaseRepository<T> repository, BaseMapper<T, TDto> mapper, BaseMapper<T, TFullDto> fullMapper)
        {
            _repository = repository;
            _mapper = mapper;
            _fullMapper = fullMapper;
        }

        internal virtual async Task<IEnumerable<TDto>> GetAll()
        {
            var all = await _repository.GetAllAsync();
            return _mapper.Map(all);
        }

        internal virtual async Task<TDto?> GetOne(int id)
        {
            var obj = await _repository.GetOneAsync(id);
            if (obj == null) return default(TDto);
            return _mapper.Map(obj);
        }

        internal abstract Task<IEnumerable<TFullDto>> GetFullAll();
        internal abstract Task<TFullDto?> GetFullOne(int id);

        internal async Task<UpdateResult> Update(TDto c)
        {
            await _repository.UpdateAsync(_mapper.Map(c));
            return new(typeof(TDto), c.Id);
        }

        internal async Task<UpdateResult> Create(TDto c)
        {
            await _repository.InsertAsync(_mapper.Map(c));
            return new(typeof(TDto), c.Id);
        }

        internal async Task<DeleteResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return new(typeof(TDto), id);
        }
    }
}
