using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI
{
    public partial class RedirectOption
    {
        [Parameter] public string Url { get; set; } = "";
        [Parameter] public string Title { get; set; } = "";
        [Parameter] public string RedirectText { get; set; } = "";
        [Parameter] public string Class { get; set; } = "";
    }
}
