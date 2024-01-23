
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Pipelines.Sockets.Unofficial;

namespace Licenta.UI.Components.Backoffice.CodeEval
{
    public partial class CodeEvalAll : BaseShowAll
    {
        private string _modalRemoveId = "modal-code-eval-remove";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                var elts = await LicentaClient.GetCodeEvaluations();
                DataTableJson json = new DataTableJson();
                json.ImportOverride(elts);

                await JSRuntime.InvokeVoidAsync("Main.InitDataTable", EltId, json, _modalRemoveId);
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        
    }
}
