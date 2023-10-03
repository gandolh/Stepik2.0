using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Components.UI.Enums
{
    public enum FilterMode
    {
        /// <summary>
        /// The component displays inline filtering UI and filters as you type.
        /// </summary>
        Simple,
        /// <summary>
        /// The component displays inline filtering UI and filters as you type combined with filter operator menu.
        /// </summary>
        SimpleWithMenu,
        /// <summary>
        /// The component displays a popup filtering UI and allows you to pick filtering operator and or filter by multiple values.
        /// </summary>
        Advanced
    }
}
