using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class Select
    {
        [Parameter] public string Class { get; set; } = string.Empty;
        [Parameter] public string Value { get; set; } = string.Empty;
        [Parameter] public EventCallback<ChangeEventArgs> Changed { get; set; }
        [Parameter] public RenderFragment Options { get; set; } = default!;
        [Parameter] public bool IsBrowserDefault { get; set; } = true; 
    }
}
