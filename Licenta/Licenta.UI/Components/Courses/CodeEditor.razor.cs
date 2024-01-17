using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Courses
{
    public partial class CodeEditor
    {
        [Parameter] public string Code { get; set; } = string.Empty;
        [Parameter] public EventCallback<string> CodeChanged { get; set; } = default!;

        private async Task HandleChange(ChangeEventArgs e)
        {
            await CodeChanged.InvokeAsync(e.Value!.ToString());
        }
    }

}
