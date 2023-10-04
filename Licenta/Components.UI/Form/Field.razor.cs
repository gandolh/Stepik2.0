using Microsoft.AspNetCore.Components;
using Components.UI.Utils;

namespace Components.UI.Form
{
    public partial class Field : NewComponent
    {
        [Parameter] public string Class { get; set; } = "";
        /// <summary>
        /// If input is horizontal aligned: label and input on same row.
        /// </summary>
        [Parameter] public bool Horizontal { get; set; } = false;
    }
}
