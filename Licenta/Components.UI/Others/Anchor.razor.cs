using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.UI.Others
{
    public partial class Anchor
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string href { get; set; } = "#";
    }
}
