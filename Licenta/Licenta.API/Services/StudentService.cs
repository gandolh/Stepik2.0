using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class StudentService : BaseCrudService<Student, StudentDto>
    {
        public StudentService(StudentRepository repository) : base(repository, new StudentMapper())
        {
        }
    }
}
