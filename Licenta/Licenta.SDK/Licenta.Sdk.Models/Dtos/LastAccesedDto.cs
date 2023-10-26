namespace Licenta.Sdk.Models.Dtos
{
    public class LastAccesedDto : LessonDto
    {
        public int Module { get; set; }
        public int Step { get; set; }
    }
}
