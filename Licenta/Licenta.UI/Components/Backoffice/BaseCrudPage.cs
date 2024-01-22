using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Backoffice
{
    public class BaseCrudPage : ComponentBase
    {
        [Parameter] public string ViewMode { get; set; } = string.Empty;
    }
}
