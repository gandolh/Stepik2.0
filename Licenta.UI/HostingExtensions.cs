using Licenta.SDK.Authentication;
using Licenta.SDK.Authentication.AccessTokenManagement;
using Licenta.SDK.Authentication.AccessTokenManagement.Interfaces;
using Licenta.SDK.Authentication.Keycloak;
using Licenta.SDK.Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Licenta.UI
{
    public static class HostingExtensions
    {

        #region localization
        /// <summary>
        /// Adaugare traduceri in aplicatie
        /// </summary>
        /// <param name="services"></param>
        private static void AddLocalization(this WebApplicationBuilder builder)
        {
            // Register localization as usual
            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = Path.Join("Localization", "Resources");
            });
            // And add out custom factory
            builder.Services.AddSingleton
                <IStringLocalizerFactory, JsonStringLocalizerFactory>();
        }
        #endregion


        #region authentication
        private static void AddMyAuthentication(
            this WebApplicationBuilder builder
            )
        {
            // register events to customize authentication handlers
            builder.Services.AddTransient<CookieEvents>();
            builder.Services.AddTransient<OidcEvents>();

            builder.Services.AddAuthentication(options =>
            {
                //Sets cookie authentication scheme
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
                options.DefaultSignOutScheme = "oidc";
            })
                      .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                      {
                          options.Cookie.SameSite = SameSiteMode.Lax;
                          options.EventsType = typeof(CookieEvents);
                      })
                      .AddOpenIdConnect("oidc", options =>
                      {
                          /*
                           * ASP.NET core uses the http://*:5000 and https://*:5001 ports for default communication with the OIDC middleware
                           * The app requires load balancing services to work with :80 or :443
                           * These needs to be added to the keycloak client, in order for the redirect to work.
                           * If you however intend to use the app by itself then,
                           * Change the ports in launchsettings.json, but beware to also change the options.CallbackPath and options.SignedOutCallbackPath!
                           * Use LB services whenever possible, to reduce the config hazzle :)
                          */

                          KeycloakConfig keycloakConfig = new();
                          builder.Configuration.GetSection("Keycloak").Bind(keycloakConfig);


                          //Use default signin scheme
                          options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                          //Keycloak server
                          options.Authority = keycloakConfig.ServerRealm;
                          //Keycloak client ID
                          options.ClientId = keycloakConfig.ClientId;
                          //Keycloak client secret
                          options.ClientSecret = keycloakConfig.ClientSecret;
                          //Token response type, will sometimes need to be changed to IdToken, depending on config.
                          options.ResponseType = OpenIdConnectResponseType.Code;
                          //Keycloak .wellknown config origin to fetch config
                          options.MetadataAddress = keycloakConfig.Metadata;
                          //Require keycloak to use SSL  ( true on production, false on debug)
                          options.RequireHttpsMetadata = builder.Environment.IsProduction();
                          // turn this off on production for GDPR 
                          // https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/wiki/PII
                          IdentityModelEventSource.ShowPII = !builder.Environment.IsProduction();
                          //Save the token
                          options.SaveTokens = true;
                          options.GetClaimsFromUserInfoEndpoint = true;
                          options.UseTokenLifetime = false;
                          options.Scope.Add("openid");
                          options.Scope.Add("profile");
                          options.Scope.Add("email");

                          options.Scope.Add("offline_access");
                          //options.TokenValidationParameters = new TokenValidationParameters { NameClaimType = "name" };

                          //SameSite is needed for Chrome/Firefox, as they will give http error 500 back, if not set to unspecified.
                          // SameSiteMode.Unspecified
                          options.NonceCookie.SameSite = SameSiteMode.Unspecified;
                          options.CorrelationCookie.SameSite = SameSiteMode.Unspecified;
                          options.TokenValidationParameters.ValidIssuers = new[]
                                {
                                    keycloakConfig.ServerRealm,
                                };
                          options.TokenValidationParameters = new TokenValidationParameters
                          {

                              //NameClaimType = "name",
                              //RoleClaimType = ClaimTypes.Role,
                              //ValidateIssuer = true
                              ValidateAudience = false
                          };

                          options.EventsType = typeof(OidcEvents);

                      });

            // adds access token management
            builder.Services.AddAccessTokenManagement();

            // not allowed to programmatically use HttpContext in Blazor Server.
            // that's why tokens cannot be managed in the login session
            builder.Services.AddSingleton<IUserAccessTokenStore, ServerSideTokenStore>();




            /*
             * For roles, that are defined in the keycloak, you need to use ClaimTypes.Role
             * You also need to configure keycloak, to set the correct name on each token.
             * Keycloak Admin Console -> Client Scopes -> roles -> mappers -> create
             * Name: "role client mapper" or whatever you prefer
             * Mapper Type: "User Client Role"
             * Multivalued: True
             * Token Claim Name: role
             * Add to access token: True
             */


            /*
             * Policy based authentication
             */
        }
        #endregion
    }
}
