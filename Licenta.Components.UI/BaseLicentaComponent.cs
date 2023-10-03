using Licenta.Components.UI.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Licenta.Components.UI
{
    /// <typeparam name="TLocalizer"></typeparam>
    public class BaseLicentaComponent<TLocalizer> : ComponentBase
    {
        [Inject] public IStringLocalizer<TLocalizer> Localizer { get; set; } = default!;
        protected PageState pageState = PageState.Initial;

    }
}
