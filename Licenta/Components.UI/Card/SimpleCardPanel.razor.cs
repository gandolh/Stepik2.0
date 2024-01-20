using Microsoft.AspNetCore.Components;

namespace Components.UI.Card
{
    public partial class SimpleCardPanel
    {
       [Parameter] public string Text { get; set; } = string.Empty;
       [Parameter] public RenderFragment? ChildContent { get; set; }
       [Parameter] public string Class { get; set; } = string.Empty;
    }
}
