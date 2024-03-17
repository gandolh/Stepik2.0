using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice
{
    public partial class LessonPage : BaseCrudPage
    {
        public FullLessonDto NewDto { get; set; } = new FullLessonDto();

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
            await httpLicentaClient.DeleteLesson(selectedId);
            await LoadDatatable();
        }

        private async Task HandleCreate()
        {
            await httpLicentaClient.CreateLesson(NewDto);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            var elts = await httpLicentaClient.GetFullLessons();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);
            DataTableColumns columns =
            [
                new DatatableColumn()
                {
                    Select = 2,
                    MaxCharacters = 60
                },
                new DatatableColumn()
                {Select = 3,
                    CellClass = "lessonBtnsTable"
                }
            ];

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId, ModalUpdateId, columns);
        }

        private void HandleUpdate()
        {

        }
    }
}
