using Components.UI.Enums;
using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class Input
    {
        [Parameter] public string Id { get; set; } = string.Empty;
        [Parameter] public string Placeholder { get; set; } = string.Empty;
        [Parameter] public string Class { get; set; } = string.Empty;
        [Parameter] public string Value { get; set; } = string.Empty;
        [Parameter] public InputType InputType { get; set; } = InputType.Text;
        [Parameter] public EventCallback<ChangeEventArgs> Changed { get; set; } = default!;

        private string GetInputType()
        {
            return InputType switch
            {
                InputType.Text => "text",
                InputType.Password => "password",
                InputType.Email => "email",
                InputType.Number => "number",
                _ => "text",
            };
        }
    }
}
