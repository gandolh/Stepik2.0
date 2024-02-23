using Components.UI.Modal;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice.Course
{
    public partial class CourseAll : BaseShowAll
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
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId);
        }

   
    }
}
