using Licenta.SDK.Menu;
using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Layout.Menu
{
    public partial class GridMenuCards<TLocalizer>
    {
        [Parameter] public ApplicationMenu Menu { get; set; } = new ApplicationMenu();
    }
}
