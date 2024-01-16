using Components.UI.Enums;
using Licenta.Sdk.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Components.UI
{
    /// <typeparam name="TLocalizer"></typeparam>
    public class BaseLicentaComp : ComponentBase
    {
        [Inject] public IStringLocalizer<ComponentResource> Localizer { get; set; } = default!;
        protected PageState pageState = PageState.Initial;

    }
}
