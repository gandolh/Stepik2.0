using Licenta.Sdk.Localization;
using Licenta.UI.Services;
using Microsoft.Extensions.Localization;

namespace Licenta.UI
{
    public static class HostingExtension
    {
        public static void AddEssentials(this WebApplicationBuilder builder)
        {
            builder.AddLocalization();
        }
        public static void AddMyServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<LicentaConfig, LicentaConfig>();
            builder.Services.AddSingleton<MyHttpClient, MyHttpClient>();
            builder.Services.AddScoped<HttpLicentaClient, HttpLicentaClient>();
            builder.Services.AddSingleton<IKafkaObserver, KafkaObserver>();
            builder.Services.AddScoped<IKafkaProducer, KafkaProducer>();
            builder.Services.AddScoped<KafkaLicentaClient, KafkaLicentaClient>();
    }


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


        public static void UseLocalization(this WebApplication app)
        {
            //var supportedCultures = new[] { "ro-RO", "en-US" };
            //var localizationOptions = new RequestLocalizationOptions()
            //    .SetDefaultCulture(supportedCultures[0])
            //    .AddSupportedCultures(supportedCultures)
            //    .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization();
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
    }
}
