using Components.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Layout
{
    public partial class Navbar : BaseLicentaComp
    {
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if(firstRender) {
                await JSRuntime.InvokeVoidAsync("MaterializeInitializer.initializeNav");
            }
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
