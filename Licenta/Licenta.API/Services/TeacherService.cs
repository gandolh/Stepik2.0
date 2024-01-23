using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _repository;
        private readonly TeacherMapper _mapper;

        public TeacherService(TeacherRepository repository)
        {
            _repository = repository;
            _mapper = new TeacherMapper();
        }


        internal async Task<IEnumerable<TeacherDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }

        internal async Task<TeacherDto> GetOne(int id)
        {
            return _mapper.Map(await _repository.GetOneAsync(id));
        }

        internal async Task<UpdateResult> Update(TeacherDto c)
        {
            await _repository.UpdateAsync(_mapper.Map(c));
            return new(typeof(TeacherDto), c.Id);
        }
        internal async Task<DeleteResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return new(typeof(TeacherDto), id);
        }
    }
}
