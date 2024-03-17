using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Form
{
    public partial class CodeEvalForm : BaseShowOne
    {
        [Parameter] public CodeEvaluationEntryDto? dto { get; set; }
        [Parameter] public EventCallback<CodeEvaluationEntryDto?> DtoChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (IsNew == false)
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
