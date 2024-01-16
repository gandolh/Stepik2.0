namespace Licenta.Db.DataModel
{
    public class Lesson
    {
        public int Id { get; set; } = 0;
        public int ModuleId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        public Lesson()
        {

        }

        public Lesson(int id, int moduleId, string name, string body)
        {
            Id = id;
            ModuleId = moduleId;
            Name = name;
            Body = body;
        }
    }
}
