using Components.UI;
using Confluent.Kafka;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Licenta.UI.Component.Pages
{
    public partial class Register : BaseLicentaComp
    {
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;
        [Inject] public NavigationManager NavManager { get; set; } = default!;

        private RegisterReqDto reqDto = new RegisterReqDto();
        private string _errorMsg = string.Empty;


        private void ToggleIsStudent()
        {
            reqDto.IsStudent = !reqDto.IsStudent;
        }

        private void ToggleIsTeacher()
        {
            reqDto.IsTeacher = !reqDto.IsTeacher;
        }


        private async Task HandleRegister()
        {
            HttpStatusCode code = await HttpLicentaClient.Register(reqDto);
            if (code == HttpStatusCode.OK)
                NavManager.NavigateTo("/login");
            else
                _errorMsg = "Utilizatorul există deja";
        }
    }
}
