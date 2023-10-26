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
        private IEnumerable<LastAccesedDto> _lastAccesedItems { get; set; } 
            = new LastAccesedDto[0];


        protected override Task OnInitializedAsync()
        {
            pageState = PageState.Loading;
            _lastAccesedItems = apiService.GetAccesedLessons();
            pageState = PageState.Success;

            return base.OnInitializedAsync();
        }
    }
}
