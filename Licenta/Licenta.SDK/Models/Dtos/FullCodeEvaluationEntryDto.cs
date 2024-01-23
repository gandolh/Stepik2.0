namespace Licenta.SDK.Models.Dtos
{
    public class FullCodeEvaluationEntryDto : CodeEvaluationEntryDto
    {
        public required ExerciseDto Exercise { get; set; }
    }
}
