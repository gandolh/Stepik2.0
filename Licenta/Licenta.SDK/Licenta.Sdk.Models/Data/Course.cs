namespace Licenta.Sdk.Models.Data
{
    public class Course
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public AccesedLesson? LastAccesedLesson { get; set;}

        public Course(){}

        public Course(string id, string name, AccesedLesson? lastAccesedLesson)
        {
            Id = id;
            Name = name;
            LastAccesedLesson = lastAccesedLesson;
        }
    }
}
