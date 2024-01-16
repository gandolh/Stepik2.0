namespace Licenta.Db.DataModel
{
    public class Module
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;


        // QUERYING
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
