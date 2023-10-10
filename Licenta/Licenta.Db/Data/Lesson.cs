namespace Licenta.Db.Data
{
    public class Lesson
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public ELessonType LessonType { get; set; }

        // if is theory lesson
        public string Theory { get; set; } = "";

        // if is quiz lesson
        public List<QuizData> quizDatas { get; set; } = new List<QuizData>();
        
        // if is code lesson
        public string ProblemQuestion { get; set; } = "";

    }


}
