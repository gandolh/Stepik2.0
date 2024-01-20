namespace Licenta.SDK.Models.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public List<TeacherDto> Teachers { get; set; } = new();
        public List<StudentDto> Students { get; set; } = new();
    }
}
