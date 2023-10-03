using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Components.UI.Enums;

namespace Licenta.Components.UI.Others
{
    public partial class Heading
    {
        //Child content paremter
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        //parameter for HeadingType
        [Parameter] public HeadingSize Size { get; set; } = HeadingSize.Is3;
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string ElementId { get; set; } = "";
    }
}
