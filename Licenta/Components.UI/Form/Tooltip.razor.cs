
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Components.UI.Form
{
    public partial class Tooltip
    {
        [Inject] public IJSRuntime jSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jSRuntime.InvokeVoidAsync("MaterializeInitializer.InitTooltip");
            }
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
