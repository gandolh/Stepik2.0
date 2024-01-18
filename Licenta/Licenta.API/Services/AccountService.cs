using Licenta.API.Mappers;
using Licenta.Db.Data;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class AccountService
    {
        private readonly StudentRepository studentRepository;
        private readonly TeacherRepository teacherRepository;
        private readonly UserRepository userRepository;
        private readonly RegisterReqUserMapper _registerReqUserMapper;
        private readonly StudentUserMapper _studentUserMapper;
        private readonly TeacherUserMapper _teacherUserMapper;

        public AccountService(StudentRepository studentRepository, TeacherRepository teacherRepository, UserRepository userRepository)
        {
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.userRepository = userRepository;
            _registerReqUserMapper = new RegisterReqUserMapper();
            _studentUserMapper = new StudentUserMapper();
            _teacherUserMapper = new TeacherUserMapper();
        }

        public async Task<User?> Login(LoginReqDto req)
        {
            var user = await userRepository.GetOne(req.Email);
            if (user == null)
                return null;

            bool isCorectPassword = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);
            if(!isCorectPassword) return null;
            return user;
        }

        public async Task<bool> Register(RegisterReqDto req)
        {
            var existingUser = await userRepository.GetOne(req.Email);
            if (existingUser != null) return false;

            User user = _registerReqUserMapper.Map(req);
            user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);

            if (req.UserType == (int)UserType.Student)
                await studentRepository.InsertAsync(_studentUserMapper.Map(user));
            else
                await teacherRepository.InsertAsync(_teacherUserMapper.Map(user));
            return true;
        }
    }
}
