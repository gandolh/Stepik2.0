using Licenta.Components.UI.Enums;
using Licenta.Components.UI.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Licenta.Components.UI.Form.Button
{
    public partial class Button : NewComponent
    {


        [Parameter] public string Text { get; set; } = "";
        [Parameter] public string? Icon { get; set; }
        [Parameter] public ButtonStyle ButtonStyle { get; set; } = ButtonStyle.Primary;
        [Parameter] public string ButtonType { get; set; } = "button";
        [Parameter] public ButtonSize Size { get; set; } = ButtonSize.Medium;
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> Click { get; set; }
        [Parameter] public string? OnJsClick { get; set; }
        [Parameter] public bool IsBusy { get; set; }
        [Parameter] public string BusyText { get; set; } = "";
        [Parameter] public bool Outlined { get; set; } = false;
        [Parameter] public bool Rounded { get; set; } = false;
        public bool IsDisabled { get => Disabled || IsBusy; }
        bool clicking;
        public async Task OnClick(MouseEventArgs args)
        {
            if (clicking)
            {
                return;
            }

            try
            {
                clicking = true;

                await Click.InvokeAsync(args);
            }
            finally
            {
                clicking = false;
            }
        }

        private string GetButtonStyleName()
        {
            return ButtonStyle switch
            {
                ButtonStyle.Primary => "primary",
                ButtonStyle.Secondary => "secondary",
                ButtonStyle.Success => "success",
                ButtonStyle.Danger => "danger",
                ButtonStyle.Warning => "warning",
                ButtonStyle.Info => "info",
                ButtonStyle.Light => "light",
                ButtonStyle.Dark => "dark",
                ButtonStyle.Link => "link",
                _ => "primary"
            };
        }

        private string GetSizeClass()
        {
            return Size switch
            {
                ButtonSize.Small => "btn-sm",
                ButtonSize.Medium => "",
                ButtonSize.Large => "btn-lg",
                ButtonSize.ExtraSmall => "",
                _ => "btn-"
            };
        }

        protected override string GetComponentCssClass()
        {
            return $"btn {(Outlined ? "btn-outline" : "btn")}-{GetButtonStyleName()} {GetSizeClass()} {(Rounded ? "rounded-pill" : "")}";
        }



    }
}
