using Components.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Pages
{
    public partial class Test : BaseLicentaComp
    {
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
              
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
