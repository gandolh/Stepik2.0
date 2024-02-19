using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class Label
    {
        [Parameter] public string Class { get; set; } = string.Empty;
        [Parameter] public string? For { get; set; }
        [Parameter] public string? Text { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }

    }
}
