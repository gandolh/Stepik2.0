using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Components.Backoffice.Teacher
{
    public partial class TeacherAll : BaseShowAll
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var elts = await LicentaClient.GetTeachers();
                DataTableJson json = new DataTableJson();
                json.ImportOverride(elts);

                await JSRuntime.InvokeVoidAsync("Main.InitDataTable", EltId, json);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
