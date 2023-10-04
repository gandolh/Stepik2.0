using Microsoft.AspNetCore.Components;
using Components.UI.Utils;

namespace Components.UI.Form
{
    public partial class TextEdit : NewComponent
    {
        [Parameter] public string Placeholder { get; set; } = "";
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public bool IsInline { get; set; } = false;
        [Parameter] public bool ChangeOnInput { get; set; } = false;
        [Parameter] public int Maxlength { get; set; } = 255;
        [Parameter] public bool Disabled { get; set; } = false;

        [Parameter] public string Text { get; set; } = "";
        [Parameter] public EventCallback<string> TextChanged { get; set; }

    }
}
