using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class ErrorDesc
    {
        [Parameter] public string Message { get; set; }
        [Parameter] public string ErrorDescription { get; set; }
        [Parameter] public bool IsVisible { get; set; }
    }
}
