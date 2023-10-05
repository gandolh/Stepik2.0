using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Licenta.Sdk.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private string ResourcesPath { get; }

        public JsonStringLocalizerFactory(IOptions<LocalizationOptions> options)
        {
            ResourcesPath = options.Value.ResourcesPath;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            // daca il vrem din diverse csproj-uri atunci folosim assembly-ul de la clasa
            // primita ca parametru
            //var resources = new EmbeddedFileProvider(resourceSource.Assembly);


            // pentru a lua doar din assembly-ul de shared traducerile si a le separa doar dupa nume
            var resources = new EmbeddedFileProvider(typeof(ComponentsResource).Assembly);
            return new JsonStringLocalizer(resources, ResourcesPath, resourceSource.Name);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            throw new NotImplementedException();
        }
    }
}
