using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Licenta.Components.UI.Layout
{
    public partial class PageTitleComp : IDisposable
    {
        [Inject] public NavigationManager NavManager { get; set; } = default!;
        private IDisposable? registration;

        private List<string> _paths = new List<string>();

        protected override Task OnInitializedAsync()
        {
            GetPath(NavManager.Uri);
            return base.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                registration = NavManager.RegisterLocationChangingHandler(LocationChangingHandler);
            }
            return base.OnAfterRenderAsync(firstRender);
        }

        private ValueTask LocationChangingHandler(LocationChangingContext arg)
        {

            GetPath(arg.TargetLocation);
            return ValueTask.CompletedTask;
        }

        private void GetPath(string uri)
        {
            _paths = NavManager
              .ToAbsoluteUri(uri)
              .AbsolutePath
              .Trim('/')
              .Split('/')
              .Select(s => "PageTitle_" + s)
              .ToList();
            _paths.RemoveAll((el) => el == Localizer[el]);
            StateHasChanged();
        }

        public void Dispose()
        {
            registration?.Dispose();
        }

        private string GetHrefByPath()
        {
            return "#";
        }

    }
}
