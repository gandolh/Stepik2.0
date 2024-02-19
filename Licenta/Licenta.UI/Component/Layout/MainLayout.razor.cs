using Licenta.SDK.Localization;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Licenta.UI.Component.Layout
{
    public partial class MainLayout
    {
        [Inject] public MyStringLocalizerFactory MyStringLocalizerFactory { get; set; } = default!;
        private MyStringLocalizer Localizer { get; set; }

        protected override Task OnInitializedAsync()
        {
            Localizer = MyStringLocalizerFactory.GetLocalizer(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
            return base.OnInitializedAsync();
        }
    }
}
