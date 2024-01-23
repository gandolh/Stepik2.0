namespace Licenta.SDK.Models.Dtos
{
    public class FullQuizVariantDto : QuizVariantDto
    {
        public required ExerciseDto Exercise { get; set; }
    }
}
