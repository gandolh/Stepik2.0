using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.DataModel
{
    public class Exercise
    {
        public int Id { get; set; } = 0;
        public int LessonId { get; set; } = 0;
        public string Enunciation { get; set; } = string.Empty;
        // 0 code / 1 quiz
        public int Type { get; set; } = 0;
        public Exercise()
        {

        }

        public Exercise(int id, int lessonId, string enunciation, int type)
        {
            Id = id;
            LessonId = lessonId;
            Enunciation = enunciation;
            Type = type;
        }

    }
}
