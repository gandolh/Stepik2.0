using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Backoffice.Module
{
    public partial class ModuleAll : BaseShowAll
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var elts = await LicentaClient.GetModules();
                DataTableJson json = new DataTableJson();
                json.ImportOverride(elts);

                await JSRuntime.InvokeVoidAsync("Main.InitDataTable", EltId, json);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
