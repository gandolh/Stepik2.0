using Licenta.API.Services;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public partial class AccountController : ControllerBase
    {
        private readonly SigningCredentials credentials;
        private readonly string jwtIssuer;
        private readonly string jwtAudience;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(2);

        private readonly AccountService _accountService;

        public AccountController(IConfiguration config, AccountService accountService)
        {
            jwtIssuer = config["Jwt:Issuer"]!;
            jwtAudience = config["Jwt:Audience"]!;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult<PortalUserDto>> GetUser(LoginReqDto req)
        {
            PortalUserDto? loggedUser = await _accountService.GetUser(req);
            return Ok(loggedUser);
        }



        [HttpPost]
        public async Task<ActionResult> Register(RegisterReqDto req)
        {
            bool registeredIn = await _accountService.Register(req);
            if (registeredIn == false) return Forbid();
            else return Ok();
        }



        [HttpPost]
        public async Task<ActionResult> JwtLogin(LoginReqDto req)
        {
            PortalUserDto? loggedUser = await _accountService.GetUser(req);
            if (loggedUser == null) return NotFound();
            else return Ok(GenerateToken(loggedUser));
        }

        private string GenerateToken(PortalUserDto user)
        {
            //TODO: implement in user a field for user role

            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new[] {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Firstname),
                new Claim(ClaimTypes.Surname, user.Lastname),
                new Claim(ClaimTypes.Role, "Student") };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = jwtIssuer,
                Audience = jwtAudience,
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            // client needs to save JWT as well include it in the Authorization Bearer Token header of subsequent requests
            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }

}
