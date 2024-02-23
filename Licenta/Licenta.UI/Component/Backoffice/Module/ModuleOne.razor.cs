using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Module
{
    public partial class ModuleOne : BaseShowOne
    {
        [Parameter] public ModuleDto? dto { get; set; }
        [Parameter] public EventCallback<ModuleDto?> DtoChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (IsNew == false)
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
