using Licenta.API.Services;
using Licenta.API.Services.Crud;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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
        private readonly string _appDataDir = 
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "licenta");

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

        [HttpGet]
        public async Task<ActionResult<string>> GetProfilePicture([FromQuery] string email)
        {
            await Task.CompletedTask;
            string profilePicDir = Path.Combine(_appDataDir, "profilePictures");
            Directory.CreateDirectory(profilePicDir);
            DirectoryInfo profileDirectory = new DirectoryInfo(profilePicDir);
            FileInfo? profilePic = profileDirectory.GetFiles(email + ".*").FirstOrDefault();
            
            
            if (profilePic == null) return NotFound();
            byte[] AsBytes = System.IO.File.ReadAllBytes(profilePic.FullName);
            String AsBase64String = Convert.ToBase64String(AsBytes);
            return Ok(AsBase64String);
        }

        [HttpPost]
        public async Task<ActionResult> PostProfilePicture([FromForm] IFormFile formFile, [FromForm] string email)
        {
            string profilePicDir = Path.Combine(_appDataDir, "profilePictures");
            Directory.CreateDirectory(profilePicDir);

            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                var bytes = memoryStream.ToArray();
                await System.IO.File.WriteAllBytesAsync(
                    Path.Combine(profilePicDir, email + "." + GetExtension(formFile.FileName)), bytes);
            }
            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        public async Task<ActionResult> Update(PortalUserDto userDto)
        {
            await _accountService.UpdateUser(userDto);
            return Ok(HttpStatusCode.OK);
        }

        private string GetExtension(string name)
        {
            return name.Substring(name.IndexOf('.') + 1);
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
