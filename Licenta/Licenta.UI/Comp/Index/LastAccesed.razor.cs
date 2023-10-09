using Components.UI;
using Licenta.Sdk.Localization;
using Licenta.Sdk.Models.Data;

namespace Licenta.UI.Comp.Index
{
    public partial class LastAccesed : BaseLicentaComp<ComponentResource>
    {

        private Course[] _lastAccesedItems { get; set; } = SampleData.GetCourses().Take(3).ToArray();
    }
}
