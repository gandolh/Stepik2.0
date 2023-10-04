using Microsoft.AspNetCore.Components;

namespace Components.UI.Form.Button
{
    public partial class ButtonContent
    {
        [Parameter][EditorRequired] public RenderFragment? ChildContent { get; set; }
        [Parameter][EditorRequired] public bool IsBusy { get; set; }
        [Parameter][EditorRequired] public string BusyText { get; set; } = "";
        [Parameter][EditorRequired] public string? Icon { get; set; }
        [Parameter][EditorRequired] public string Text { get; set; } = "";

    }
}
