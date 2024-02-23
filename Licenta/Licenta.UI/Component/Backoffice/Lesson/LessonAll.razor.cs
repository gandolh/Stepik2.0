using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.Lesson
{
    public partial class LessonAll : BaseShowAll
    {
        public LessonDto NewDto { get; set; } = new LessonDto();

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
            var elts = await httpLicentaClient.GetLessons();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);

            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId);
        }
    }
}
