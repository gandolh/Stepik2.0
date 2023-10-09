using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Comp.Courses
{
    public partial class CodeRunnerPanel
    {
        [Inject] private IJSRuntime JsRuntime { get; set; } = default!;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                JsRuntime.InvokeVoidAsync("MonacoEditorUtils.initialize", "codePanelId",
                    "function x() {\n" + 
	                "   console.log(\"Hello world!\");\n" +
                    "}", "javascript");

            }
            base.OnAfterRender(firstRender);
        }
    }
}
