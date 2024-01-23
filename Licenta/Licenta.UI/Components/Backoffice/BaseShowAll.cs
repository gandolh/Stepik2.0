﻿using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel;

namespace Licenta.UI.Components.Backoffice
{
    public class BaseShowAll : ComponentBase, IAsyncDisposable
    {
        protected const string EltId = "example";
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected HttpLicentaClient LicentaClient { get; set; } = default!;

        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("Main.DestroyDataTable", EltId);
        }
    }
}
