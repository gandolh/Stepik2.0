using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class StudentService : BaseCrudService<Student, StudentDto, StudentDto>
    {
        public StudentService(StudentRepository repository) : base(repository, new StudentMapper(), new StudentMapper())
        {
        }

        internal override async Task<IEnumerable<StudentDto>> GetFullAll()
        {
            return await base.GetAll();
        }

        internal override async Task<StudentDto> GetFullOne(int id)
        {
            return await base.GetOne(id);
        }
    }
}
