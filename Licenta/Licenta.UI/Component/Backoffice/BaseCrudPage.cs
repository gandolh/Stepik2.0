using Components.UI;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice
{
    public class BaseCrudPage : BaseLicentaComp
    {
        [Parameter] public string ViewMode { get; set; } = string.Empty;
        [Parameter] public int? Id { get; set; }

    }
}
