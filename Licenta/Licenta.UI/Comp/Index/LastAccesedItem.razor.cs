using Components.UI;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Data;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Index
{
    public partial class LastAccesedItem : BaseLicentaComp<ComponentResource>
    {
        [Parameter][EditorRequired] public Course AccesedLesson { get; set; } = default!;
    }
}
