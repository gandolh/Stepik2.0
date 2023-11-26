using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Data
{
    internal class Exercise
    {
        public string Id { get; set; } = string.Empty;
        public string LessonId { get; set; } = string.Empty;
        public string Enunciation { get; set; } = string.Empty;
        // 0 code / 1 quiz
        public int Type { get; set; } = 0;

    }
}
