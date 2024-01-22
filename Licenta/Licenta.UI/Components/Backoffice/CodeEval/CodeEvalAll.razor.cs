
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Licenta.UI.Components.Backoffice.CodeEval
{
    public partial class CodeEvalAll
    {
        private const string EltId = "example";

        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] public HttpLicentaClient LicentaClient { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                List<CodeEvaluationEntryDto> elts = await LicentaClient.GetCodeEvaluations();
                DataTableJson json = new DataTableJson();
                json.ImportOverride(elts);

                await JSRuntime.InvokeVoidAsync("Main.InitDataTable", EltId, json);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
