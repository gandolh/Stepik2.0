namespace Licenta.Sdk.Models.Data
{
    public class Lesson
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        public Lesson(){}

        public Lesson(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
