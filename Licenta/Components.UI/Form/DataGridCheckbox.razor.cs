using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class DataGridCheckbox
    {
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public bool Checked { get; set; } = false;
        [Parameter] public string Name { get; set; } = "";
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

        private async Task ChangeCheck(ChangeEventArgs e)
        {
            await CheckedChanged.InvokeAsync((bool)(e.Value ?? false));
        }
    }
}
