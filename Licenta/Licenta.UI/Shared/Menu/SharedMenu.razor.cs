using Licenta.Sdk.Localization;
using Licenta.UI.Menu;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Licenta.UI.Shared.Menu
{
    public partial class SharedMenu
    {
        [Inject] private IStringLocalizer<ComponentResource> Localizer { get; set; } = default!;
        [Parameter][EditorRequired] public ApplicationMenu MenuItem { get; set; } = new ApplicationMenu();
    }
}
