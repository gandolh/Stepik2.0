namespace Licenta.Db.Data
{
    public class Submission
    {
        public int Id { get; set; } = 0;
        // % out of 100
        public int points { get; set; } = 0;
        public int StudentId { get; set; } = 0;
        public int ExerciseId { get; set; } = 0;
    }
}
