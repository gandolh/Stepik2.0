using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Backoffice.Layout
{
    public partial class CrudPageLayout
    {
        [Parameter] public RenderFragment ChildContent { get; set; } = default!;
        private string[][] _navItems = [
            ["Course","course"],
            ["Module","module"],
            ["Lesson","lesson"],
            ["Exercise","exercise"],
            ["Quiz variant", "quizvar"],
            ["Code evaluation entry","codeeval"],

        ];

    }
}
