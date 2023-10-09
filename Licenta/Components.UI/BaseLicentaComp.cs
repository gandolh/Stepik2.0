using Components.UI.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Components.UI
{
    /// <typeparam name="TLocalizer"></typeparam>
    public class BaseLicentaComp<TLocalizer> : ComponentBase
    {
        [Inject] public IStringLocalizer<TLocalizer> Localizer { get; set; } = default!;
        protected PageState pageState = PageState.Initial;

    }
}
