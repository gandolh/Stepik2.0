using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class FieldBody
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string Style { get; set; } = "";

    }
}
