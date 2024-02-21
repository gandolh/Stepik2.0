using Licenta.SDK.Models.Dtos;
using Licenta.SDK.Services;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Licenta.UI.Controllers
{
    [ApiController]
    [Route("api")]
    public class CookieController : ControllerBase
    {
        private readonly HttpLicentaClient _httpLicentaClient;

        public CookieController(HttpLicentaClient httpLicentaClient)
        {
            _httpLicentaClient = httpLicentaClient;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginCookies(LoginReqDto req)
        {
                PortalUserDto? loggedUser = await _httpLicentaClient.GetUser(req);
                if (loggedUser == null) return NotFound();
                await GenerateCookies(loggedUser);
                return Ok("It worked");
        }

        [HttpPost("logout")]
        public async Task<ActionResult> LogoutCookies()
        {
            await HttpContext.SignOutAsync("Cookies");
            return Ok("It worked");
        }

        private async Task GenerateCookies(PortalUserDto user)
        {

            
            var claimList = new[] {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Firstname),
                new Claim(ClaimTypes.Surname, user.Lastname),
                new Claim(ClaimHelper.RolesClaimType, JsonSerializer.Serialize(user.Roles))};
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimList, "auth");
            ClaimsPrincipal claims = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Cookies", claims);
        }
    }
}
