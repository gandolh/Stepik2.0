﻿using Licenta.SDK.Localization;
using Licenta.SDK.Menu;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Licenta.Components.UI.Layout.Menu
{
    public partial class SharedMenu
    {
        [Inject] private IStringLocalizer<ComponentsResource> Localizer { get; set; } = default!;
        [Parameter][EditorRequired] public ApplicationMenu MenuItem { get; set; } = new ApplicationMenu();
    }
}
