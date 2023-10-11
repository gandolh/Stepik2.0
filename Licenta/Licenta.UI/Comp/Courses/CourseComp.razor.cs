using Licenta.Sdk.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Courses
{
    public partial class CourseComp
    {
        [Parameter][EditorRequired] public CourseDto Course { get; set; } = default!;
        private int CurrentStep = 3;

        private void HandlePrev()
        {
            CurrentStep--;
        }

        private void HandleNext()
        {
            CurrentStep++;
        }
    }
}
