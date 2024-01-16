namespace Licenta.SDK.Models.Dtos
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();
    }
}
