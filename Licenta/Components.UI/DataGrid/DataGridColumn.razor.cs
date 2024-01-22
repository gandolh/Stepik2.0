using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Components.UI.DataGrid
{
    public partial class DataGridColumn<TItem>
    {
        // Grid-ul de care apartine coloana
        [CascadingParameter] public DataGrid<TItem?>? OwnerGrid { get; set; }
        // Proprietatea din TItem care să fie citită
        [Parameter] public string Property { get; set; } = "";
        // header template
        [Parameter] public RenderFragment? HeaderTemplate { get; set; }
        // cell template
        [Parameter] public RenderFragment<TItem>? Template { get; set; }
        // Titlul coloanei daca nu este oferit un template
        [Parameter] public string Title { get; set; } = "";

        private PropertyInfo? _propertyInfo;

        // adaugare referinta la o coloana in Grid-ul parinte
        protected override Task OnInitializedAsync()
        {
            OwnerGrid?.AddColumn(this);
            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            if (_propertyInfo == null)
                _propertyInfo = typeof(TItem).GetProperty(Property);
            return base.OnParametersSetAsync();
        }

        #region render header
        internal RenderFragment Header { get { return CreateHeader(); } }
        private RenderFragment CreateHeader()
        {
            if (HeaderTemplate != null)
                return HeaderTemplate;
            return __builder =>
            {
                __builder.OpenElement(0, "text");
                if (!string.IsNullOrEmpty(Title))
                    __builder.AddContent(1, Title);
                else
                    __builder.AddContent(2, Property);
                __builder.CloseElement();
            };

        }
        #endregion
        #region render cell


        internal RenderFragment CreateCell(TItem data)
        {
            if (Template != null)
                return Template(data);
            string value = _propertyInfo?.GetValue(data)?.ToString() ?? "";
            return __builder =>
            {
                __builder.OpenElement(0, "text");
                __builder.AddContent(1, value);
                __builder.CloseElement();
            };
        }
        #endregion

        [Parameter] public bool Sortable { get; set; } = true;
    }
}
