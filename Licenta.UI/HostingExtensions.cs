using Licenta.SDK.Localization;
using Microsoft.Extensions.Localization;

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



    }
}
