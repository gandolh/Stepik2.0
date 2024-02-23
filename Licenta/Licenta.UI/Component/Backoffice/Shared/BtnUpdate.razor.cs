using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Shared
{
    public partial class BtnUpdate
    {
        [Parameter] public EventCallback OnUpdate { get; set; }
    }
}
