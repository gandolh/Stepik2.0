using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice
{
    public partial class ShowAllLayout
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public EventCallback OnSaving { get; set; } = default!;
        [Inject] public NavigationManager NavManager { get; set; } = default!;
        [Inject] public IJSRuntime JsRuntime { get; set; } = default!;

        private string GetAllUrl()
        {
            int index = NavManager.Uri.IndexOf("/one");
            if(index != -1)
            return NavManager.Uri.Substring(0, index);
            return NavManager.Uri;
        }
        
        private async Task HandleSaving()
        {
           await OnSaving.InvokeAsync();
            await JsRuntime.InvokeVoidAsync("Main.showToast", "Date actualizate", "success");
        }
    }
}
