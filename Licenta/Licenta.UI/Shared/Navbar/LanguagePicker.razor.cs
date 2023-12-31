﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace Licenta.UI.Shared.Navbar
{
    public partial class LanguagePicker
    {
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;


        private CultureInfo[] suportedCultures = new[]
 {
                new CultureInfo("ro-RO"),
                new CultureInfo("en-US")
    };

        private string _cultureName = "";
        protected override void OnInitialized()
        {
            SetCultureInfo(CultureInfo.CurrentCulture.Name);
        }

        private CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture.Name != value.Name)
                {
                    var uri = new Uri(Navigation.Uri)
                        .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                    var cultureEscaped = Uri.EscapeDataString(value.Name);
                    var uriEscaped = Uri.EscapeDataString(uri);

                    Navigation.NavigateTo(
                        $"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
                        forceLoad: true);
                }
            }
        }

        private void SetCultureInfo(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName)) return;
            _cultureName = cultureName;
            Culture = new CultureInfo(cultureName);
        }

    }
}
