
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Layout
{
    public partial class UnathenticatedGroupBtn
    {
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // todo: remove in prod
                await JSRuntime.InvokeVoidAsync("Auth.handleLogin", "admin", "admin");
            }

            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
