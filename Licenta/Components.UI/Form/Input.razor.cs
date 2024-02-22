using Components.UI.Enums;
using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class Input
    {
        [Parameter] public string? Id { get; set; }
        [Parameter] public string? Placeholder { get; set; } 
        [Parameter] public string? Value { get; set; }
        [Parameter] public string Class { get; set; } = string.Empty;
        [Parameter] public InputType InputType { get; set; } = InputType.Text;
        [Parameter] public EventCallback<string> ValueChanged { get; set; } = default!;
        [Parameter] public string Name { get; set; } = String.Empty;
        [Parameter] public bool? Disabled { get; set; } = null;
        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? Attributes { get; set; }


        private string GetInputType()
        {
            return InputType switch
            {
                InputType.Text => "text",
                InputType.Password => "password",
                InputType.Email => "email",
                InputType.Number => "number",
                InputType.Radio => "radio",
                InputType.Check => "checkbox",
                _ => "text",
            };
        }

        private void _ValueChanged(ChangeEventArgs e)
        {
            ValueChanged.InvokeAsync(e.Value!.ToString());
        }
    }
}
