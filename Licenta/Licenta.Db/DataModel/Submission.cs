using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Data
{
    internal class Submission
    {
        public int Id { get; set; } = 0;
        // % out of 100
        public int points { get; set; } = 0;
        public int StudentId { get; set; } = 0;
        public int ExerciseId { get; set; } = 0;
    }
}
