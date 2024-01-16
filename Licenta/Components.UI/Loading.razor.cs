using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.UI
{
    public partial class Loading
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public string Label { get; set; } = "";
        [Parameter] public string Class { get; set; } = "w-100 h-100";
    }
}
