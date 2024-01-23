namespace Licenta.SDK.Models.Dtos
{
    public class ExerciseDto : IDtoWithId
    {
        public int Id { get; set; } = 0;
        public int LessonId { get; set; } = 0;
        public string Enunciation { get; set; } = string.Empty;
        public string SampleInput { get; set; } = string.Empty;


        // if type code
        public bool IsCodeRunner { get; set; }


    }
}
