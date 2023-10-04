using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using Components.UI.Utils;
using Components.UI.Enums;

namespace Components.UI.Others
{
    public partial class Icon
    {
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string ElementId { get; set; } = "";
        [Parameter] public string Style { get; set; } = "";
        [Parameter] public IconSize IconSize { get; set; } = IconSize.h6;
        [Parameter] public IconName Name { get; set; } = IconName.None;
        [Parameter] public IconStyle IconStyle { get; set; } = IconStyle.Regular;
        [Parameter] public EventCallback Clicked { get; set; }
        // needs to be valid css color
        [Parameter] public string Color { get; set; } = "";

        private string GetSizeClasses()
        {
            return IconSize switch
            {
                IconSize.h1 => "h1",
                IconSize.h2 => "h2",
                IconSize.h3 => "h3",
                IconSize.h4 => "h4",
                IconSize.h5 => "h5",
                IconSize.h6 => "h6",
                IconSize.None => "",
                _ => "h6",
            };
        }


        private string GetClasses()
        {
            return $"{ClassnameProvider.getClassname(Name)} {Class} {GetSizeClasses()}";
        }

    }
}
