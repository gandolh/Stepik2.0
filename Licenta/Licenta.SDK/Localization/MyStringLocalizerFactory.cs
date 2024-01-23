using Microsoft.Extensions.FileProviders;
using System.Collections.Frozen;
using System.Text.Json;

namespace Licenta.SDK.Localization
{
    /// <summary>
    /// singleton ce stocheaza dictionare cu traducerile
    /// </summary>
    public class MyStringLocalizerFactory
    {
        private readonly MyStringLocalizer _roLocalizer;
        private readonly MyStringLocalizer _enLocalizer;
        private readonly MyStringLocalizer _fallbackLocalizer;

        public MyStringLocalizerFactory(IFileInfo roResource, IFileInfo enResource, IFileInfo fallbackResource)
        {
            FrozenDictionary<string, string> roDictionary = ReadLocalizationFile(roResource).ToFrozenDictionary();
            FrozenDictionary<string, string> enDictionary = ReadLocalizationFile(enResource).ToFrozenDictionary();
            FrozenDictionary<string, string> fallbackDictionary = ReadLocalizationFile(fallbackResource).ToFrozenDictionary();
            _roLocalizer = new MyStringLocalizer(roDictionary);
            _enLocalizer = new MyStringLocalizer(enDictionary);
            _fallbackLocalizer = new MyStringLocalizer(fallbackDictionary);

        }

        public MyStringLocalizer GetLocalizer(string cultureName)
        {
            return cultureName switch
            {
                "ro" => _roLocalizer,
                "en" => _enLocalizer,
                _ => _fallbackLocalizer
            };
        }

        private Dictionary<string, string> ReadLocalizationFile(IFileInfo fileInfo)
        {
            if (fileInfo.Exists)
            {
                using var stream = fileInfo.CreateReadStream();

                return JsonSerializer.DeserializeAsync<Dictionary<string, string>>(stream).Result
                    ?? throw new Exception("Cannot read localization");
            }

            return new Dictionary<string, string>();
        }


    }
}
