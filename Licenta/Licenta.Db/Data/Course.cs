namespace Licenta.Db.Data
{
    public class Course
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
