using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Shared
{
    public partial class ModalAddItem
    {
        [Parameter] public EventCallback HandleCreate { get; set; }
        [Parameter] public string ModalCreateId {get;set;} = string.Empty;
        [Parameter] public string ModalTitle { get;set;} = string.Empty;
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
    }
}
