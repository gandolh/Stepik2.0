using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Backoffice.CodeEval
{
    public partial class CodeEvalOne : BaseShowOne
    {
        public CodeEvaluationEntryDto? dto { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dto = await HttpLicentaClient.GetOneCodeEvaluation(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
