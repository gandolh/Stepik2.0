using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Components.Backoffice.Module
{
    public partial class ModuleOne : BaseShowOne
    {
        public ModuleDto? dto { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dto = await HttpLicentaClient.GetOneModule(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateModule(dto);
        }
    }
}
