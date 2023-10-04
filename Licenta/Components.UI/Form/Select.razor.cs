using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class Select<TValue>
    {
        [Parameter] public RenderFragment Label { get; set; } = default!;
        [Parameter] public RenderFragment Content { get; set; } = default!;
        [Parameter] public RenderFragment Error { get; set; } = default!;
        [Parameter] public TValue SelectedValue { get; set; } = default!;

        [Parameter] public EventCallback<TValue> SelectedValueChanged { get; set; }
        //parameter Class of type string
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string LabelClass { get; set; } = "";
        [Parameter] public string RowClass { get; set; } = "";
        [Parameter] public string RowStyle { get; set; } = "";
        //parameter ElementId of type string
        [Parameter] public string ElementId { get; set; } = "";
        [Parameter] public string AriaLabel { get; set; } = "Default select example";
        [Parameter] public bool Disabled { get; set; }

        private async Task ChangeSelectedValue(ChangeEventArgs e)
        {
            TValue? value = (TValue?)Convert.ChangeType(e.Value, typeof(TValue));
            await SelectedValueChanged.InvokeAsync(value);
        }

    }
}
