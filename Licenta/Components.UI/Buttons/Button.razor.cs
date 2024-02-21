using Components.UI.Enums;
using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace Components.UI.Buttons
{
    public partial class Button
    {
        [Parameter] public ButtonColor Color { get; set; } = ButtonColor.Primary;
        [Parameter] public ColorTint Tint { get; set; } = ColorTint.normal;
        [Parameter] public ButtonSize Size { get; set; } = ButtonSize.Medium;
        [Parameter] public ButtonStyle Style { get; set; } = ButtonStyle.Normal;
        [Parameter] public ButtonType Type { get; set; } = ButtonType.Button;
        [Parameter] public EventCallback Clicked { get; set;  } = default!;
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Name { get; set; } = string.Empty;
        [Parameter] public string OnJsClick { get; set;  } = string.Empty;
        [Parameter] public string Class { get; set;  } = string.Empty;
        [Parameter] public string AriaLabel { get; set;  } = string.Empty;
        [Parameter] public bool Animation { get; set;  } = true;
        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? Attributes { get; set; }

        private string GetSizeClass()
        {
            return Size switch
            {
                ButtonSize.Small => "btn-small",
                ButtonSize.Medium => "",
                ButtonSize.Large => "btn-large",
                _ => ""
            };
        }

        private string GetColorClass()
        {
            return Color switch
            {
                ButtonColor.Primary => "",
                ButtonColor.Secondary => "grey",
                ButtonColor.Green => "green",
                ButtonColor.Red => "red",
                _ => ""
            };
        }

        private string GetColorTintClass()
        {
            return Tint switch
            {
                ColorTint.lighten5 => "lighten-5",
                ColorTint.lighten4 => "lighten-4",
                ColorTint.lighten3 => "lighten-3",
                ColorTint.lighten2 => "lighten-2",
                ColorTint.lighten1 => "lighten-1",
                ColorTint.normal => "normal",
                ColorTint.darken1 => "darken-1",
                ColorTint.darken2 => "darken-2",
                ColorTint.darken3 => "darken-3",
                ColorTint.darken4 => "darken-4",
                ColorTint.darken5 => "darken-5",
                _ => ""
            };
        }

        private string GetButtonType()
        {
            return Type switch
            {
                ButtonType.Button => "button",
                ButtonType.Submit => "submit",
                _ => "button",
            };
        }

        private string GetButtonStyleClass()
        {
            return Style switch
            {
                ButtonStyle.Normal => "btn" + (Animation ? " waves-effect waves-light": ""),
                ButtonStyle.None => "",
                _ => "",
            };
        }
    }
}
