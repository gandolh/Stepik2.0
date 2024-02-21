using Licenta.API.Mappers;
using Licenta.Db.Data;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class AccountService
    {
        private readonly UserRepository _userRepository;
        private readonly RegisterReqUserMapper _registerReqUserMapper;
        private readonly UserMapper _userMapper;

        public AccountService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
            _registerReqUserMapper = new RegisterReqUserMapper();
            _userMapper = new UserMapper();
        }

        public async Task<PortalUserDto?> GetUser(LoginReqDto req)
        {
            var user = await _userRepository.GetOne(req.Email);
            if (user == null)
                return null;

            bool isCorectPassword = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);
            if(!isCorectPassword) return null;
            return _userMapper.Map(user);
        }

        public async Task<bool> Register(RegisterReqDto req)
        {
            var existingUser = await _userRepository.GetOne(req.Email);
            if (existingUser != null) return false;

            PortalUser user = _registerReqUserMapper.Map(req);
            user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);
            await _userRepository.InsertAsync(user);
            return true;
        }
    }
}
