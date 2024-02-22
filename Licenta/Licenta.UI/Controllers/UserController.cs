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
    public class UserController : ControllerBase
    {
        private readonly HttpLicentaClient _httpLicentaClient;

        public UserController(HttpLicentaClient httpLicentaClient)
        {
            _httpLicentaClient = httpLicentaClient;
        }

        [HttpPost("uploadPicture")]
        public async Task<ActionResult> UploadPicture([FromForm] IFormFile file)
        {
            string email = ClaimHelper.GetEmail(User);
            await _httpLicentaClient.PostProfilePicture(file, email);
            return Ok("It worked");
        }

     
    }
}
