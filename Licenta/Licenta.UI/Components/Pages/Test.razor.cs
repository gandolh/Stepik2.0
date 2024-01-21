using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Pages
{
    public partial class Test
    {
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
              await JSRuntime.InvokeVoidAsync("Main.initializeEditor", "code-editor",
                  "// First line\nfunction hello() {\n\talert('Hello world!');\n}\n// Last line",
                  "javascript");
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
