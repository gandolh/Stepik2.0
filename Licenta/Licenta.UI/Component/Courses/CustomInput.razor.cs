using Components.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Courses
{
    public partial class CustomInput : BaseLicentaComp
    {
        [Parameter] public string Value { get; set; } = string.Empty;
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;


        private async Task HandleValueChanged(ChangeEventArgs e)
        {
            await ValueChanged.InvokeAsync(e.Value!.ToString());
        }
    }
}
