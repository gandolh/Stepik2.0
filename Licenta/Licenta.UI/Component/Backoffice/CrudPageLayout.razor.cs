using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice
{
    public partial class CrudPageLayout
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;

        private List<string> CrudPages = new List<string>()
        {
            "Quiz variant", "Code evaluation entry", "Exercise", "Lesson", "Module", "Student", "User", "Course"
        };

        private List<string> CrudHrefPages = new List<string>()
        {
            "quizvar", "codeeval", "exercise", "lesson", "module", "student", "teacher", "course"
        };

       
    }
}
