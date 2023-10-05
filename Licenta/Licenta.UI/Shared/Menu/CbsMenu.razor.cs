using Licenta.Sdk.Localization;
using Licenta.SDK.Menu;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Licenta.UI.Shared.Menu
{
    public partial class CbsMenu
    {
        [Inject] private IStringLocalizer<ComponentsResource> Localizer { get; set; } = default!;
        [Parameter][EditorRequired] public ApplicationMenu MenuItem { get; set; } = new ApplicationMenu();
    }
}
