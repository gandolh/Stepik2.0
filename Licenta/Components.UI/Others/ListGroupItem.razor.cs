using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace Components.UI.Others
{
    public partial class ListGroupItem
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public bool IsLast { get; set; } = false;
        [Parameter] public string OnJsClick { get; set; } = "";
    }
}
