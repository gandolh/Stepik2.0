using Microsoft.AspNetCore.Components;
using Licenta.Components.UI.Utils;

namespace Licenta.Components.UI.Form
{
    public partial class Switch : NewComponent
    {
        [Parameter] public string ElementId { get; set; } = "";
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public bool Checked { get; set; } = false;
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

        private async Task ChangeCheck(ChangeEventArgs e)
        {
            await CheckedChanged.InvokeAsync((bool)(e.Value ?? false));
        }
    }
}
