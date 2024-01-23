namespace Licenta.SDK.Models.Dtos
{
    public class FullExerciseDto : ExerciseDto
    {
        // if type quiz
        public List<QuizVariantDto> QuizVariants { get; set; } = new();
        public List<CodeEvaluationEntryDto> CodeEvaluationEntries { get; set; } = new();
    }
}
