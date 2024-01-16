using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.UI.Card
{
    public partial class CardReveal
    {
        [Parameter] public string CardTitle { get; set; } = "Card Title";
        [Parameter] public string CardDescription { get; set; } = "Here is some more information about" +
            " this product that is only revealed once clicked on.";
        [Parameter] public string ImgSrc { get; set; } = "imgs/backgroundCourse.jpg";
        [Parameter] public string AnchorText { get; set; } = "This is a link";
        [Parameter] public string AnchorHref { get; set; } = "#";
    }
}
