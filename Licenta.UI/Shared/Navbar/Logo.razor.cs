using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace Licenta.UI.Shared.Navbar
{
    public partial class Logo
    {
        [Inject] public IJSRuntime jSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await jSRuntime.InvokeVoidAsync("JSShared.AddBurgerNavbar");
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
