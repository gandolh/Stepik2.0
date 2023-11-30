namespace Licenta.Db.DataModel
{
    public class Lesson
    {
        public int Id { get; set; } = 0;
        public int CourseId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public Lesson()
        {

        }

        public Lesson(int id, int courseId, string name)
        {
            Id = id;
            CourseId = courseId;
            Name = name;
        }
    }
}
