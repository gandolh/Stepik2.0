using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class CheckBox
    {
        [Parameter] public string Name { get; set; } = String.Empty;
        [Parameter] public string Text { get; set; } = String.Empty;
        [Parameter] public bool Checked { get; set; }
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }
        [Parameter] public bool? Disabled { get; set; } = null; 
        [Parameter] public string? CheckBoxId { get; set; }

        private async Task Changed(string e)
        {
            bool newChecked = bool.Parse(e);
            Checked = newChecked;
            await CheckedChanged.InvokeAsync(newChecked);
        }
    }
}
