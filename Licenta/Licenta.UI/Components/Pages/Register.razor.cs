using Confluent.Kafka;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Licenta.UI.Components.Pages
{
    public partial class Register
    {
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;
        [Inject] public NavigationManager NavManager { get; set; } = default!;

        public int _activeIndex = 0;
        private RegisterReqDto reqDto = new RegisterReqDto();
        private string _errorMsg = string.Empty;


        private void SelectRole(int index)
        {
            _activeIndex = index;
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
