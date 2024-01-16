using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Pages
{
    public partial class Course
    {
        [Parameter] public int Id { get; set; } = 0;
        [Inject] IJSRuntime JSRuntime { get; set; } = default!;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                JSRuntime.InvokeVoidAsync("Main.initializeCollapsible");
            }

            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
