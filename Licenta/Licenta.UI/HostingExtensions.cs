using Licenta.DataAccessService;
using Licenta.DataAccessService.Interfaces;
using Licenta.SDK.Authentication;
using Licenta.SDK.Authentication.AccessTokenManagement;
using Licenta.SDK.Authentication.AccessTokenManagement.Interfaces;
using Licenta.SDK.Authentication.Keycloak;
using Licenta.SDK.Config;
using Licenta.SDK.Interfaces;
using Licenta.SDK.Localization;
using Licenta.SDK.Logging.Console;
using Licenta.SDK.Logging.File;
using Licenta.SDK.Menu;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
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

                          //KeycloakConfig keycloakConfig = new();
                          var keycloakConfig = new KeycloakConfig();
                          builder.Configuration.GetSection("AppConfig:Keycloak").Bind(keycloakConfig);
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


        #region Logging
        private static void ConfigureLogger(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddFileLogger();
            builder.Logging.AddConsoleLogger();
        }

        #endregion

        #region Custom Platform services
        public static WebApplicationBuilder AddCbsServices(this WebApplicationBuilder builder)
        {
            #region HttpClients
            builder.Services.AddHttpContextAccessor();

            // TODO: Specific kafka clients


            // TODO: Specific httpClients

            #endregion

            return builder;
        }


        #endregion



        #region Configure Services
        /// <summary>
        /// Add services to the container.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.ConfigureLogger();
            builder.AddLocalization();

            builder.Services.AddScoped<IMenuContributor, MenuContributor>();

            // KAFKA
            builder.Services.AddSingleton<IEbusListener, EbusListener>();
            builder.Services.AddScoped<IMyKafkaClient, MyKafkaClient>();


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // add controllers
            builder.Services.AddControllers();

            builder.AddMyAuthentication();



            //TODO: Add Httpclients and services dynamic for every solution
            // Use environment, namespace, special folder or config
            // copy all config.json and edit it specially


            return builder.Build();
        }


        private static void UseLocalization(this WebApplication app)
        {
            var supportedCultures = new[] { "ro-RO", "en-US" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
        }


        /// <summary>
        /// Sa se foloseasca inainte de ConfigureBlazor 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static WebApplication UseBasePath(this WebApplication app, string basePath)
        {
            app.UsePathBase(basePath);
            return app;
        }


        #endregion
        /// <summary>
        ///  Configure the Blazor pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication ConfigureBlazor(this WebApplication app)
        {
            app.UseLocalization();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            //app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.MapControllers();

            return app;
        }

    }
}
