using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


/// TODO: implement disposable flow
/// TODO: add button for code compillation
/// TODO: add section for problem to be solved
/// TODO: implement check mechanism


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
