using Components.UI;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Comp.Index
{
    public partial class DeadlineItem : BaseLicentaComp<ComponentResource>
    {
        [Parameter][EditorRequired] public EventDto ToDoItem { get; set; } = default!; 
    }
}
