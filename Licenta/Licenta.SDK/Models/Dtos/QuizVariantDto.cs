using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models.Dtos
{
    public class QuizVariantDto : IDtoWithId
    {
        public int Id { get; set; } = 0;
        public int ExerciseId { get; set; } = 0;
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } = false;
    }
}
