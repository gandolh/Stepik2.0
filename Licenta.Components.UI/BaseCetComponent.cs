using Licenta.Components.UI.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Licenta.Components.UI
{
    /// <summary>
    /// Cet = CertEntTrust
    /// </summary>
    /// <typeparam name="TLocalizer"></typeparam>
    public class BaseCetComponent<TLocalizer> : ComponentBase
    {
        [Inject] public IStringLocalizer<TLocalizer> Localizer { get; set; } = default!;
        protected PageState pageState = PageState.Initial;

    }
}
