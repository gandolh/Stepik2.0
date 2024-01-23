using Licenta.SDK;
using Licenta.SDK.Localization;
using Licenta.UI.Services;
using Microsoft.Extensions.FileProviders;

namespace Licenta.UI
{
    public static class HostingExtension
    {
        public static void AddEssentials(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication("Cookies").AddCookie();
            builder.AddLocalization();
            builder.Services.AddControllers();
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
            var fileProvider = new EmbeddedFileProvider(typeof(SdkAssemblyRef).Assembly);
            var resourcesPath = Path.Join("Localization", "Resources");
            var roResource = fileProvider.GetFileInfo(Path.Combine(resourcesPath, $"Resource-ro.json"));
            var enResource = fileProvider.GetFileInfo(Path.Combine(resourcesPath, $"Resource-en.json"));
            var fallbackResource = fileProvider.GetFileInfo(Path.Combine(resourcesPath, $"Resource.json"));
            MyStringLocalizerFactory myStringLocalizer = new MyStringLocalizerFactory(roResource, enResource, fallbackResource);
            builder.Services.AddSingleton(myStringLocalizer);
        }


        public static void UseLocalization(this WebApplication app)
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
    }
}
