using Components.UI;
using Components.UI.Enums;
using Licenta.Sdk.Localization;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Shared.Navbar
{
    public partial class EmptyDropdown : BaseLicentaComp<ComponentResource>
    {
        [Parameter][EditorRequired] public PageState ParentPageState { get; set; }
        [Parameter] public IconName IconNameParam { get; set; }
        [Parameter] public string ErrorLabel { get; set; } = "";
        [Parameter] public string EmptyLabel { get; set; } = "";

    }
}
