using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Components.Backoffice.QuizVariant
{
    public partial class QuizVariantOne : BaseShowOne
    {
        public QuizVariantDto? dto { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dto = await HttpLicentaClient.GetOneQuizVariant(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
