namespace Licenta.Db.DataModel
{
    internal class Student_Course
    {
        public int StudentId { get; set; } = 0;
        public int CourseId { get; set; } = 0;

        public Student_Course()
        {
        }

        public Student_Course(int studentId, int courseId)
        {                     
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
