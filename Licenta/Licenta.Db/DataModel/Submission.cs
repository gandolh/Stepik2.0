namespace Licenta.Db.DataModel
{
    public class Submission
    {
        public int Id { get; set; } = 0;
        // % out of 100
        public int Points { get; set; } = 0;
        public int StudentId { get; set; } = 0;
        public int ExerciseId { get; set; } = 0;

        public Submission()
        {

        }

        public Submission(int id, int points, int studentId, int exerciseId)
        {
            Id = id;
            Points = points;
            StudentId = studentId;
            ExerciseId = exerciseId;
        }
    }
}
