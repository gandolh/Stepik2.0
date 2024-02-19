using Components.UI.Enums;
using Microsoft.AspNetCore.Components;

namespace Components.UI.Form
{
    public partial class InputField
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public ColSize ColSize { get; set; }
        [Parameter] public string Class { get; set; } = string.Empty;

        private string GetSizeClass()
        {
            return ColSize switch
            {
                ColSize.S1 => "s1",
                ColSize.S2 => "s2",
                ColSize.S3 => "s3",
                ColSize.S4 => "s4",
                ColSize.S5 => "s5",
                ColSize.S6 => "s6",
                ColSize.S7 => "s7",
                ColSize.S8 => "s8",
                ColSize.S9 => "s9",
                ColSize.S10 => "s10",
                ColSize.S11 => "s11",
                ColSize.S12 => "s12",
                _ => "",
            };
        }
    }
}
