namespace Licenta.Db.DataModel
{
    public class Exercise
    {
        public int Id { get; set; } = 0;
        public int LessonId { get; set; } = 0;
        public string Enunciation { get; set; } = string.Empty;
        // 0 code / 1 quiz
        public ExerciseType Type { get; set; } = 0;
        public Exercise()
        {

        }

        public Exercise(int id, int lessonId, string enunciation, int type)
        {
            Id = id;
            LessonId = lessonId;
            Enunciation = enunciation;
            Type = (ExerciseType)type;
        }
    

        // for QUERYING
        public List<QuizVariant> QuizVariants { get; set; } = new List<QuizVariant>();
        public List<CodeEvaluationEntry> CodeEvaluationEntries { get; set; } = new List<CodeEvaluationEntry>();
    }
}
