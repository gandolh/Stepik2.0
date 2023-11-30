using Licenta.Sdk.Config;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Logging.Console;
using Licenta.Sdk.Logging.File;
using Licenta.UI.Menu;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System.Net.Http;

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
        private static void AddMyAuthentication(this WebApplicationBuilder builder)
        {
         
        }
        #endregion


        #region Logging
        private static void ConfigureLogger(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            //builder.Logging.AddFileLogger();
            builder.Logging.AddConsoleLogger();
        }

        #endregion

        #region Custom Platform services
        public static WebApplicationBuilder AddLicentaServices(this WebApplicationBuilder builder)
        {
            #region HttpClients
            builder.Services.AddHttpContextAccessor();

            #endregion

            return builder;
        }


        #endregion

        private static void AddHttpClients(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient("Api", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://Licenta.API:8081/api");
            }).ConfigureHttpMessageHandlerBuilder(builder =>
            {
                builder.PrimaryHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
                };
            }); ;
        }

        #region Configure Services
        /// <summary>
        /// Add services to the container.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();


            builder.ConfigureLogger();
            builder.AddLocalization();
            builder.AddHttpClients();


            // add controllers
            builder.Services.AddControllers();
            builder.AddMyAuthentication();
                

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

            //app.UseHttpsRedirection();

            //app.UseCookiePolicy(new CookiePolicyOptions()
            //{
            //    MinimumSameSitePolicy = SameSiteMode.None,
            //    Secure = CookieSecurePolicy.None
            //});

            app.UseStaticFiles();
            app.UseRouting();

            //app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();

            app.MapControllers();

            return app;
        }

    }
}
