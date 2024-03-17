using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Form
{
    public partial class QuizVariantForm : BaseShowOne
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
