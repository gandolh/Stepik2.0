using Components.UI;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel;

namespace Licenta.UI.Components.Backoffice
{
    public class BaseShowAll : BaseLicentaComp, IAsyncDisposable
    {
        protected const string EltId = "example";
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected HttpLicentaClient httpLicentaClient { get; set; } = default!;
        protected string _modalRemoveId = "modal-show-all-remove";

        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.DestroyDataTable", EltId);
        }
    }
}
