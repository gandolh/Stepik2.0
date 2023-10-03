using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Components.UI.Utils;

namespace Licenta.Components.UI.Form
{
    public partial class Radio : NewComponent
    {
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public string Name { get; set; } = "";
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }
        [Parameter] public bool Checked { get; set; } = false;
        private void ChangeRadioInput(ChangeEventArgs e)
        {
            CheckedChanged.InvokeAsync(true);
        }
    }
}
