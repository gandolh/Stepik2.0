using Components.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Courses
{
    public partial class CustomInput : BaseLicentaComp
    {
        [Parameter] public string Value { get; set; } = string.Empty;
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;


        private async void HandleValueChanged(ChangeEventArgs e)
        {
            await ValueChanged.InvokeAsync(e.Value!.ToString());
        }
    }
}
