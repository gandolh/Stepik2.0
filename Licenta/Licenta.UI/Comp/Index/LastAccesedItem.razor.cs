using Components.UI;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Index
{
    public partial class LastAccesedItem : BaseLicentaComp<ComponentResource>
    {
        [Parameter][EditorRequired] public LastAccesedDto AccesedLesson { get; set; } = default!;
        [Parameter] public string courseName { get; set; } = "";
    }
}
