using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Backoffice.Student
{
    public partial class StudentAll : BaseShowAll
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
            await httpLicentaClient.DeleteStudent(selectedId);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            var elts = await httpLicentaClient.GetStudents();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId);
        }
    }
}
