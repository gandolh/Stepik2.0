using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models.Dtos
{
    public class FullLessonDto : LessonDto, IDtoWithId
    {
        public List<FullExerciseDto> Exercises { get; set; } = new(); 
    }
}
