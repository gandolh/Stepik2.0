using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db.DataModel
{
    internal class Course_Teacher
    {
        public int CourseId { get; set; } = 0;
        public int TeacherId { get; set; } = 0;

        public Course_Teacher()
        {

        }

        public Course_Teacher(int courseId, int teacherId)
        {
            CourseId = courseId;
            TeacherId = teacherId;
        }
    }
}
