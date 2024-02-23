using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.Module
{
    public partial class ModuleAll : BaseShowAll
    {
        public ModuleDto NewDto { get; set; } = new ModuleDto();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadDatatable();
                
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        protected override async Task HandleRemove(int selectedId)
        {
            await httpLicentaClient.DeleteModule(selectedId);
            await LoadDatatable();
        }

        private async Task HandleCreate()
        {
            await httpLicentaClient.CreateModule(NewDto);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            var elts = await httpLicentaClient.GetModules();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId);
        }
    }
}
