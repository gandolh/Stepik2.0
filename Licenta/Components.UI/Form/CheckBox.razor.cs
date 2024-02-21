using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class CheckBox
    {
        [Parameter] public string Name { get; set; } = String.Empty;
        [Parameter] public string Text { get; set; } = String.Empty;
        [Parameter] public bool Checked { get; set; } 
        [Parameter] public string? CheckBoxId { get; set; }

        private void Changed(string e)
        {

        }
    }
}
