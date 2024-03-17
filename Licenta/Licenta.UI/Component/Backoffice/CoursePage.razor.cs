using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Licenta.UI.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice
{
    public partial class CoursePage : BaseCrudPage
    {
        public CourseDto NewDto { get; set; } = new CourseDto();

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
            await httpLicentaClient.DeleteCourse(selectedId);
            await LoadDatatable();
        }

        private async Task HandleCreate()
        {
            await httpLicentaClient.CreateCourse(NewDto);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            List<FullCourseDto> elts = await httpLicentaClient.GetFullCourses();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId, ModalUpdateId);
        }

        private void HandleUpdate()
        {

        }
    }
}
