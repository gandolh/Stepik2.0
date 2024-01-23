using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Components.Backoffice.Student
{
    public partial class StudentOne : BaseShowOne
    {
        public StudentDto? dto { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dto = await HttpLicentaClient.GetOneStudent(Id);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task HandleSaving()
        {
            await HttpLicentaClient.UpdateStudent(dto);
        }
    }
}
