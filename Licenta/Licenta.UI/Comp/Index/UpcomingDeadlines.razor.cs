using Components.UI;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Data;

namespace Licenta.UI.Comp.Index
{
    public partial class UpcomingDeadlines : BaseLicentaComp<ComponentResource>
    {
        private ToDoItem[] _toDoItems = new ToDoItem[]{
            new ToDoItem("Stepik 2.0", new DateTime(2024,08,28),"Proiect licenta")
        };
    }
}
