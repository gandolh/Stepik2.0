using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Components.UI.Enums;

namespace Components.UI.Others
{
    public partial class Tooltip
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public TooltipPlacement Placement { get; set; } = TooltipPlacement.Top;
        [Parameter] public string Text { get; set; } = "";
        [Inject] IJSRuntime JsRuntime { get; set; } = default!;

        protected override async void OnAfterRender(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync("JSShared.addTooltips");
            base.OnAfterRender(firstRender);
        }
    }
}
