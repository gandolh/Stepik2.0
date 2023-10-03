using Licenta.Components.UI.Enums;
using Licenta.SDK.Localization;
using Microsoft.AspNetCore.Components;

namespace Licenta.Components.UI.Layout.Navbar
{
    public partial class EmptyDropdown : BaseCetComponent<ComponentsResource>
    {
        [Parameter][EditorRequired] public PageState ParentPageState { get; set; }
        [Parameter] public Enums.IconName IconNameParam { get; set; }
        [Parameter] public string ErrorLabel { get; set; } = "";
        [Parameter] public string EmptyLabel { get; set; } = "";

    }
}
