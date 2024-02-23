using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.QuizVariant
{
    public partial class QuizVariantOne : BaseShowOne
    {
        [Parameter] public QuizVariantDto? dto { get; set; }
        [Parameter] public EventCallback<QuizVariantDto?> DtoChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (IsNew == false)
                    dto = await HttpLicentaClient.GetOneQuizVariant(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateQuizVariant(dto);
        }
    }
}
