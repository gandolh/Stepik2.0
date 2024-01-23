using Licenta.API.Mappers;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class StudentService
    {
        private readonly StudentRepository _repository;
        private readonly StudentMapper _mapper;

        public StudentService(StudentRepository repository)
        {
            _repository = repository;
            _mapper = new StudentMapper();
        }

        internal async Task<IEnumerable<StudentDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }

        internal async Task<StudentDto> GetOne(int id)
        {
            return _mapper.Map(await _repository.GetOneAsync(id));
        }
    }
}
