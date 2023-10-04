using Licenta.SDK.Menu;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Shared.Menu
{
    public partial class GridMenuCards<TLocalizer>
    {
        [Parameter] public ApplicationMenu Menu { get; set; } = new ApplicationMenu();
    }
}
