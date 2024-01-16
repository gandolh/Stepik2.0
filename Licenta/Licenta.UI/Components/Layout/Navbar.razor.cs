using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Layout
{
    public partial class Navbar
    {
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if(firstRender) {
                await JSRuntime.InvokeVoidAsync("Main.initializeNav");
            }
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
