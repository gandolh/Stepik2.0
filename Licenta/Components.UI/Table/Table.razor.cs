using Microsoft.AspNetCore.Components;

namespace Components.UI.Table
{
    public partial class Table<TItem>
    {
        [Parameter] public RenderFragment Columns { get; set; } = default!;
        [Parameter] public IEnumerable<TItem> Data { get; set; } = default!;
        [Parameter] public IList<TItem> Value { get; set; } = default!;
        [Parameter] public EventCallback<IList<TItem>> ValueChanged { get; set; } = default!;
        [Parameter] public EventCallback<TItem> OnSelectRow { get; set; }
        [Parameter] public bool Bordered { get; set; } = false;
        [Parameter] public string TableStyle { get; set; } = "";
        public string DataTableId = Guid.NewGuid().ToString();

        private readonly List<TableColumn<TItem>> _columns = new List<TableColumn<TItem>>();
        private TItem? _selectedItem;
        // GridColumn uses this method to add a column
        internal void AddColumn(TableColumn<TItem> column)
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
            await base.OnAfterRenderAsync(firstRender);
        }

        private void HandleSelectRow(TItem item)
        {
            _selectedItem = item;
            if (OnSelectRow.HasDelegate)
                OnSelectRow.InvokeAsync(item);
        }

    }
}
