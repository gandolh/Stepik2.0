using Components.UI;
using Licenta.UI;
using Licenta.UI.Pages;

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .AddLicentaServices()
    .ConfigureServices()
    .UseBasePath("/portal")
    .ConfigureBlazor();


app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddAdditionalAssemblies(typeof(ComponentsSdkAssembly).Assembly);
app.Run();