using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Backoffice
{
    public partial class ShowAllLayout
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Inject] public NavigationManager NavManager { get; set; } = default!;

        private string GetAllUrl()
        {
            int index = NavManager.Uri.IndexOf("/one");
            if(index != -1)
            return NavManager.Uri.Substring(0, index);
            return NavManager.Uri;
        }
    }
}
