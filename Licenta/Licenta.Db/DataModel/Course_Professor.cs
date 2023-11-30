using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.DataModel
{
    internal class Course_Professor
    {
        public int CourseId { get; set; } = 0;
        public int ProfessorId { get; set; } = 0;

        public Course_Professor()
        {

        }

        public Course_Professor(int courseId, int professorId)
        {
            CourseId = courseId;
            ProfessorId = professorId;
        }
    }
}
