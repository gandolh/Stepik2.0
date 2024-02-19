using Components.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Courses
{
    public partial class CodeEditor : BaseLicentaComp
    {
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;
        private string _code { get; set; } = CodeSamplers.CppStartCode;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("Main.initializeEditor", 
                    "code-editor", _code, "cpp");
            }

            await base.OnAfterRenderAsync(firstRender);
        }

    }

}
