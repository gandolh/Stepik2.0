using Components.UI;
using Components.UI.Enums;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Index
{
    public partial class UpcomingDeadlines : BaseLicentaComp<ComponentResource>
    {

        [Inject] IApiService apiService { get; set; } = default!;
        private IEnumerable<EventDto> _events = new EventDto[0];

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            pageState = PageState.Loading;
            _events = await apiService.GetEvents(after: DateTime.Now);
            pageState = PageState.Success;
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
