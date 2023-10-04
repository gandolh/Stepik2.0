using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class SelectItem<TValue>
    {
        [CascadingParameter] protected virtual Select<TValue>? ParentSelect { get; set; } = default;
        //parameter ChildContent of type Render Fragment
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        //parameter value of type TValue
        [Parameter] public TValue? Value { get; set; } = default;
        //parameter Disabled of type bool
        [Parameter] public bool Disabled { get; set; } = false;
        protected string StringValue => Value?.ToString() ?? "";


    }
}
