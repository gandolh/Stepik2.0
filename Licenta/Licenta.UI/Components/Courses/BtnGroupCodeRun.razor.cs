using Components.UI;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Courses
{
    public partial class BtnGroupCodeRun : BaseLicentaComp
    {
        [Parameter] public EventCallback OnRunCode {get;set;} = default!;
        [Parameter] public EventCallback OnSubmitCode { get; set; } = default!;

    }
}
