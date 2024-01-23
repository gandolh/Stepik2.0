using Licenta.SDK.Models.Dtos;

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

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateCodeEvaluation(dto);
        }
    }
}
