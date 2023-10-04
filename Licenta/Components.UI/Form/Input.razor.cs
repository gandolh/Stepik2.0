using Microsoft.AspNetCore.Components;
using Components.UI.Utils;
using Components.UI.Enums;

namespace Components.UI.Form
{
    public partial class Input : NewComponent
    {
        [Parameter] public string Placeholder { get; set; } = "";
        [Parameter] public InputType Type { get; set; } = InputType.Text;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public bool IsInline { get; set; } = false;
        [Parameter] public int Maxlength { get; set; } = 255;
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public bool ChangeOnInput { get; set; } = false;
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public string Value { get; set; } = "";



        private async Task HandleOnChange(ChangeEventArgs e)
        {
            if (!ChangeOnInput)
            {
                await ValueChanged.InvokeAsync((string)(e.Value ?? ""));
            }
        }

        private async Task HandleOnInput(ChangeEventArgs e)
        {
            if (ChangeOnInput)
            {
                await ValueChanged.InvokeAsync((string)(e.Value ?? ""));
            }
        }

        private string getInputTypeParameter()
        {
            return Type switch
            {
                InputType.Text => "text",
                InputType.Password => "Password",
                InputType.Email => "Email",
                InputType.Number => "Number",
                InputType.Tel => "Tel",
                InputType.Url => "Url",
                InputType.Search => "Search",
                InputType.Color => "Color",
                InputType.Date => "Date",
                InputType.File => "file",
                _ => "",
            };
        }

    }
}
