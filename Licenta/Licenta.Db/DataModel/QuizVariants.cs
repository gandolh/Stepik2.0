using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Data
{
    internal class QuizVariants
    {
        public int Id { get; set; } = 0;
        public int ExerciseId { get; set; } = 0;
        public string Text { get; set; } = string.Empty;
        public bool IsCorect { get; set; } = false;
    }
}
