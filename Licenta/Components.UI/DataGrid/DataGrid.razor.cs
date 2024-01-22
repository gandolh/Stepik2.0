using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Components.UI.DataGrid
{
    public partial class DataGrid<TItem> : IAsyncDisposable
    {

        [Parameter] public RenderFragment Columns { get; set; } = default!;
        [Parameter] public IEnumerable<TItem> Data { get; set; } = default!;
        [Parameter] public bool Bordered { get; set; } = true;
        [Parameter] public bool Hoverable { get; set; } = true;
        [Parameter] public string AdditionalClasses { get; set; } = "";

        [Inject] IJSRuntime JsRuntime { get; set; } = default!;

        public string DataTableId = Guid.NewGuid().ToString();


        private readonly List<DataGridColumn<TItem>> _columns = new List<DataGridColumn<TItem>>();
        // GridColumn uses this method to add a column
        internal void AddColumn(DataGridColumn<TItem> column)
        {
            _columns.Add(column);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // The first render will instantiate the GridColumn defined in the ChildContent.
                // GridColumn calls AddColumn during its initialization. This means that until
                // the first render is completed, the columns collection is empty.
                // Calling StateHasChanged() will re-render the component, so the second time it will know the columns
                StateHasChanged();
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("JSShared.InitializeDatatable", DataTableId);
            }
            await base.OnAfterRenderAsync(firstRender);
        }



        public async ValueTask DisposeAsync()
        {
            await JsRuntime.InvokeVoidAsync("JSShared.DisposeDatatable", DataTableId);
        }
    }
}
