using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class RadioButton
    {
        [Parameter] public EventCallback<string> Changed { get; set; }
        [Parameter] public string Name { get; set; } = String.Empty;
        [Parameter] public string Text { get; set; } = String.Empty;
        [Parameter] public string Value { get; set; } = String.Empty;
        [Parameter] public string? RadioId { get; set; }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
