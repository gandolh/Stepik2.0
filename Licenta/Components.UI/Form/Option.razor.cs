using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class Option
    {
       [Parameter] public string Value { get; set; } = string.Empty;
       [Parameter] public string Text { get; set; } = string.Empty;
    }
}
