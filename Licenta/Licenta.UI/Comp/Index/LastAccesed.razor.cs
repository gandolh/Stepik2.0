using Components.UI;
using Components.UI.Enums;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Index
{
    public partial class LastAccesed : BaseLicentaComp<ComponentResource>
    {
        [Inject] public IApiService apiService { get; set; } = default!;
        private List<LastAccesedDto> _lastAccesedItems { get; set; } 
            = new List<LastAccesedDto>();


        protected override async Task OnInitializedAsync()
        {
            pageState = PageState.Loading;
            _lastAccesedItems = (await apiService.GetAccesedLessons("")).ToList();
            pageState = PageState.Success;

            await base.OnInitializedAsync();
        }
    }
}
