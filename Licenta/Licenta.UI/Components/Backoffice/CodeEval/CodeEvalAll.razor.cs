﻿
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Backoffice.CodeEval
{
    public partial class CodeEvalAll : BaseShowAll
    {
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
