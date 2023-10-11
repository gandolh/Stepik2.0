namespace Licenta.Sdk.Models.Dtos
{
    public class CourseDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public AccesedLessonDto? LastAccesedLesson { get; set; }

        public CourseDto() { }

        public CourseDto(string id, string name, AccesedLessonDto? lastAccesedLesson)
        {
            Id = id;
            Name = name;
            LastAccesedLesson = lastAccesedLesson;
        }
    }
}
