using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.QuizVariant
{
    public partial class QuizVariantAll : BaseShowAll
    {
        public QuizVariantDto NewDto { get; set; } = new QuizVariantDto();


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
            await httpLicentaClient.DeleteQuizVariant(selectedId);
            await LoadDatatable();
        }

        private async Task HandleCreate()
        {
            await httpLicentaClient.CreateQuizVariant(NewDto);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            var elts = await httpLicentaClient.GetFullQuizVariants();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId);
        }
    }
}
