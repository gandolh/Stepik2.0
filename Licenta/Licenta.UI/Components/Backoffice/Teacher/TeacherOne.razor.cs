using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Components.Backoffice.Teacher
{
    public partial class TeacherOne : BaseShowOne
    {
        public TeacherDto? dto { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dto = await HttpLicentaClient.GetOneTeacher(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateTeacher(dto);
        }

    }
}
