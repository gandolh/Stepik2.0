using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models.Dtos
{
    public class Notification
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime Emitted { get; set; } = DateTime.Now;



    }
}
