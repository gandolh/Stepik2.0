namespace Licenta.Db.DataModel
{
    public class CodeEvaluationEntry
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public string Input { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;

        public CodeEvaluationEntry()
        {
            
        }

        public CodeEvaluationEntry(int id, int exerciseId, string input, string expectedResult)
        {
            Id = id;
            ExerciseId = exerciseId;
            Input = input;
            ExpectedResult = expectedResult;
        }
    }
}
