using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace Licenta.Components.UI.Stepper
{
    public partial class Step
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        [Parameter] public int index { get; set; } = 0;
        [Parameter] public int currentIndex { get; set; } = 0;
        [Parameter] public bool isLast { get; set; } = false;

        private bool isCurrent() => index == currentIndex;
        private bool isCompleted() => index < currentIndex;
        private string getTextStyle()
        {
            if (isCurrent())
                return "text-blue-600 fw-bold";
            else if (isCompleted())
                return "text-green-600 fw-bold";
            else return "";
        }
    }
}