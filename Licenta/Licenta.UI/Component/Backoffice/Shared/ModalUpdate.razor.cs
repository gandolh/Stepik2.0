using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Shared
{
    public partial class ModalUpdate
    {
        [Parameter] public EventCallback HandleUpdate { get; set; }
        [Parameter] public string ModalId { get;set;} = string.Empty;
        [Parameter] public string ModalTitle { get;set;} = string.Empty;
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        
    }
}
