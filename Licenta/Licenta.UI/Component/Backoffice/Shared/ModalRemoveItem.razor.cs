using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Shared
{
    public partial class ModalRemoveItem
    {
        [Parameter] public EventCallback HandleRemove { get; set; }
        [Parameter] public string ModalRemoveId { get; set; }  = string.Empty;
        [Parameter] public string Modaltitle { get; set; } = string.Empty;
    }
}
