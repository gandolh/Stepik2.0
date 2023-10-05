using Licenta.Sdk.Config;
using Licenta.Sdk.Identity.AccessTokenManagement.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Licenta.UI.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly KeycloakConfig _keycloakConfig;
        private readonly IUserAccessTokenStore _userAccessTokenStore;

        [FromQuery(Name = "postLogoutRedirectUri")]
        public string PostLogoutRedirectUri { get; set; } = "";

        public LogoutModel(IConfiguration iConfig, IUserAccessTokenStore userAccessTokenStore)
        {
            _keycloakConfig = new KeycloakConfig();
            iConfig.GetSection("AppConfig:Keycloak").Bind(_keycloakConfig);
            _userAccessTokenStore = userAccessTokenStore;
        }
        public IActionResult OnGetAsync()
        {
            //return Redirect("/");
            //https://stackoverflow.com/questions/76484792/logout-issue-on-blazor-oidc-client
            var ID_TOKEN_HINT = this.HttpContext.GetTokenAsync("id_token").Result;
            string LOGOUT_URL = $"{_keycloakConfig.OidcProtocol}/logout";

            //string CLIENT_ID = "myclient";
            //add this to ask for logout in keycloak
            //client_id ={CLIENT_ID} 
            //id_token_hint={ID_TOKEN_HINT} add this to not ask for logout and just logout
            string Formatted_LOGOUT_URI = $"{LOGOUT_URL}?post_logout_redirect_uri={PostLogoutRedirectUri}&id_token_hint={ID_TOKEN_HINT}";
            SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
            if(HttpContext.User.Identities.First().IsAuthenticated == true)
                _userAccessTokenStore.ClearTokenAsync(HttpContext.User);
            return Redirect(Formatted_LOGOUT_URI);
        }
    }
}
