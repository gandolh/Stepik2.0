namespace Licenta.Db.DataModel
{
    public class QuizVariant
    {
        public int Id { get; set; } = 0;
        public int ExerciseId { get; set; } = 0;
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } = false;
        public QuizVariant()
        {

        }

        public QuizVariant(int id, int exerciseId, string text, bool isCorrect)
        {
            Id = id;
            ExerciseId = exerciseId;
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}
