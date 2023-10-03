using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Components.UI.Enums
{
    public enum DataGridSelectionMode
    {
        /// <summary>
        /// The user can select only one row at a time. Selecting a different row deselects the last selected row.
        /// </summary>
        Single,
        /// <summary>
        /// The user can select multiple rows.
        /// </summary>
        Multiple
    }
}
