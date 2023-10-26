namespace Licenta.Sdk.Models.Dtos
{
    public class CourseDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public LastAccesedDto? LastAccesedLesson { get; set; }

        public CourseDto() { }

        public CourseDto(string id, string name, LastAccesedDto? lastAccesedLesson)
        {
            Id = id;
            Name = name;
            LastAccesedLesson = lastAccesedLesson;
        }
    }
}
