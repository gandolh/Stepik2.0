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
        private readonly RoleRepository _roleRepository;
        private readonly RegisterReqUserMapper _registerReqUserMapper;
        private readonly UserMapper _userMapper;

        public AccountService(UserRepository userRepository, RoleRepository roleRepository)
        {
            this._userRepository = userRepository;
            _roleRepository = roleRepository;
            _registerReqUserMapper = new RegisterReqUserMapper();
            _userMapper = new UserMapper();
        }

        public async Task<PortalUserDto?> GetUser(LoginReqDto req)
        {
            var user = await _userRepository.GetOne(req.Email);
            if (user == null)
                return null;

            List<Role> roles = await _roleRepository.GetAllByUserIdAsync(user.Id);
            user.Roles = roles.Select(el => (int)el.type).ToList();
            bool isCorectPassword = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);
            if (!isCorectPassword) return null;
            return _userMapper.Map(user);
        }

        public async Task<bool> Register(RegisterReqDto req)
        {
            var existingUser = await _userRepository.GetOne(req.Email);
            if (existingUser != null) return false;

            PortalUser user = _registerReqUserMapper.Map(req);
            user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);
            await _userRepository.InsertAsync(user);
            var savedUser = await GetUser(new LoginReqDto(user.Email, req.Password));
            foreach (var role in user.Roles)
            {
                await _roleRepository.InsertAsync(new Role(-1, (RoleType)role, savedUser!.Id));
            }
            return true;
        }
    }
}
