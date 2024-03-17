﻿using Components.UI;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Layout
{
    public abstract class BaseShowOne : BaseLicentaComp
    {
        [Parameter] public int Id { get; set; }
        [Parameter] public bool IsNew { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;


    }
}