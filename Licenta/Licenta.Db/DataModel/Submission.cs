using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.Data
{
    internal class Submission
    {
        public string Id { get; set; } = string.Empty;
        // % out of 100
        public int points { get; set; } = 0;
        public string StudentId { get; set; } = string.Empty;
        public string ExerciseId {  get; set; } = string.Empty;
    }
}
