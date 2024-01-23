using Components.UI;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Courses
{
    public partial class ResultCodeRun : BaseLicentaComp
    {
        [Parameter][EditorRequired] public required CodeRunResultDto CodeResult { get; set; }
    }
}
