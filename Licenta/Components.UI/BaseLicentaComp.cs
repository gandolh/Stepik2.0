using Components.UI.Enums;
using Licenta.SDK.Localization;
using Microsoft.AspNetCore.Components;

namespace Components.UI
{
    public class BaseLicentaComp : ComponentBase
    {
        [CascadingParameter] public MyStringLocalizer Localizer { get; set; } = default!;
        protected PageState pageState = PageState.Initial;
    }
}
