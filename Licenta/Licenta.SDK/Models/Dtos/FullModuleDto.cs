namespace Licenta.SDK.Models.Dtos
{
    public class FullModuleDto : IDtoWithId
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<FullLessonDto> Lessons { get; set; } = new List<FullLessonDto>();
    }
}
