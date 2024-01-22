using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models.Dtos
{
    public class LessonDto : IDtoWithId
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
