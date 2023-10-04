using Microsoft.AspNetCore.Components;
using Components.UI.Enums;

namespace Components.UI.Badge
{
    public partial class Badge
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public Color Color { get; set; } = Color.Undefined;
        [Parameter] public BadgeStyle BadgeStyle { get; set; } = BadgeStyle.Primary;
        [Parameter] public bool Outlined { get; set; } = false;
        [Parameter] public bool Rounded { get; set; } = false;

        private string GetBadgeStyleName()
        {
            return BadgeStyle switch
            {
                BadgeStyle.Primary => "primary",
                BadgeStyle.Secondary => "secondary",
                BadgeStyle.Success => "success",
                BadgeStyle.Danger => "danger",
                BadgeStyle.Warning => "warning",
                BadgeStyle.Info => "info",
                BadgeStyle.Light => "light",
                BadgeStyle.Dark => "dark",
                _ => "primary"
            };
        }

        private string GetBadgeClass()
        {
            string styleName = GetBadgeStyleName();
            string variantClassName = !Outlined ?
                $"bg-{styleName}" :
                $"border-{styleName} border-1 ";
            return $"badge solid  {variantClassName} {(Rounded ? "rounded-pill" : "")} " +
                $"{(styleName != "light" ? "" : "text-dark")}";
        }
    }
}
