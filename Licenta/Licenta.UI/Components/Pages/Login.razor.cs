using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Licenta.UI.Components.Pages
{
    public partial class Login
    {
        [Inject] HttpLicentaClient HttpLicentaClient { get; set; } = default!;
        [Inject] NavigationManager NavManager { get; set; } = default!;
        private LoginReqDto reqDto = new LoginReqDto();
        private string _errorMsg = string.Empty;

        private async Task HandleLogin()
        {
         HttpStatusCode code = await HttpLicentaClient.Login(reqDto);
            if (code == HttpStatusCode.OK)
                NavManager.NavigateTo("/");
            else
                _errorMsg = "Perechea email și parolă este invalidă";
        }
    }
}
