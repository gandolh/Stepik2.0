using Microsoft.AspNetCore.Components;
using Licenta.Components.UI.Utils;

namespace Licenta.Components.UI.Form
{
    public partial class CheckBox : NewComponent
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
