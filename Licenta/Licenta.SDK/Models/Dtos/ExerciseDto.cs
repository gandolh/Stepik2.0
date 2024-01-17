namespace Licenta.SDK.Models.Dtos
{
    public class ExerciseDto
    {
        public int Id { get; set; } = 0;
        public int LessonId { get; set; } = 0;
        public string Enunciation { get; set; } = string.Empty;
        public string SampleInput { get; set; } = string.Empty;


        // if type code
        public bool IsCodeRunner { get; set; }

        // if type quiz
        public List<QuizVariantDto> QuizVariants { get; set; } = new();
        public List<CodeEvaluationEntryDto> CodeEvaluation { get; set; } = new();
    }
}
