using Licenta.API.Mappers;
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
    }
}
