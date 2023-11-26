using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Data
{
    internal class QuizVariants
    {
        public string Id { get; set; } = string.Empty;
        public string ExerciseId { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool IsCorect { get; set; } = false;
    }
}
