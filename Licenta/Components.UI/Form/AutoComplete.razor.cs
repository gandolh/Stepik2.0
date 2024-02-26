using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Components.UI.Form
{
    public partial class AutoComplete
    {
        [Parameter] public RenderFragment Icon { get; set; } = default!;
        [Parameter] public string AutocompleteId { get; set; } = string.Empty;
        [Parameter] public string Label { get; set; } = string.Empty;
        [Parameter] public AutoCompleteData? Data { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("MaterializeInitializer.initializeAutocomplete", AutocompleteId, Data);
            }
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
