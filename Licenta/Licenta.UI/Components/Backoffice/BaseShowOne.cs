using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Backoffice
{
    public class BaseShowOne : ComponentBase
    {
        [Parameter] public int Id { get; set; }
        [Parameter] public bool Disabled { get; set; } 
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;

    }
}
