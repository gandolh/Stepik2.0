using Components.UI;
using Licenta.UI.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.JSInterop;
using System.Diagnostics.Contracts;

namespace Licenta.UI.Components.Layout
{
    public partial class ProfileCard : BaseLicentaComp
    {
        [Parameter] public string Fullname { get;set; } = string.Empty;
        [Parameter] public string Email { get;set; } = string.Empty;
        [Inject] public IJSRuntime jSRuntime { get; set; } = default!;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
            }

            
            jSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDropdown", new DropdownOptions()
            {
                ContainerId = "user-menu-container",
                CoverTrigger = false
            });
            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
