using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Licenta.UI.Pages
{
    public class LoginModel : PageModel
    {
        // https://stackoverflow.com/questions/60231899/rules-for-binding-query-parameters-in-razor-pages
        // from the Microsoft.AspNetCore.Mvc namespace
        [FromQuery(Name = "redirectUri")]
        public string RedirectUri { get; set; } = "";

        public async Task OnGet()
        {
            await HttpContext.ChallengeAsync("oidc", new AuthenticationProperties { RedirectUri = RedirectUri });
        }
    }
}
