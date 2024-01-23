using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Backoffice.Lesson
{
    public partial class LessonAll : BaseShowAll
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadDatatable();
                await JSRuntime.InvokeVoidAsync("MicroModal.init");
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task HandleRemove(int selectedId)
        {
            await httpLicentaClient.DeleteLesson(selectedId);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            var elts = await httpLicentaClient.GetLessons();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("Main.InitDataTable", EltId, json, _modalRemoveId);
        }
    }
}
