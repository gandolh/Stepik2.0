using Components.UI;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Courses
{
    public partial class ProgrammingLangSelect : BaseLicentaComp
    {
        [Parameter] public CodeLanguage Language { get; set; } = CodeLanguage.Cpp;
        [Parameter] public EventCallback<CodeLanguage> LanguageChanged { get; set; }

        private async Task HandleLanguageChanged(ChangeEventArgs e)
        {
            int selectedOption = Int32.Parse(e.Value.ToString() ?? "0");
            await LanguageChanged.InvokeAsync((CodeLanguage)selectedOption);
        }
    }
}
