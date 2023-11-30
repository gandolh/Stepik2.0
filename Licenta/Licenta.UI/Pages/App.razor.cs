using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Licenta.UI.Pages
{
    public partial class App : IComponent
    {
        [CascadingParameter] public HttpContext? HttpContext { get; set; }
        protected override Task OnInitializedAsync()
        {
            HttpContext!.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(
            CultureInfo.CurrentCulture,
            CultureInfo.CurrentUICulture)));
            return base.OnInitializedAsync();
        }
    }
}
