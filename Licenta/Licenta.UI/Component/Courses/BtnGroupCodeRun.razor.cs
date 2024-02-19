using Components.UI;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Component.Courses
{
    public partial class BtnGroupCodeRun : BaseLicentaComp
    {
        [Parameter] public EventCallback OnRunCode {get;set;} = default!;
        [Parameter] public EventCallback OnSubmitCode { get; set; } = default!;

    }
}
