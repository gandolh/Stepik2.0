namespace Licenta.Sdk.Models.Dtos
{
    public class AccesedLessonDto : LessonDto
    {
        public int Module { get; set; }
        public int Step { get; set; }
    }
}
