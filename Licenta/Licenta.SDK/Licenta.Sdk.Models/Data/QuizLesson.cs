namespace Licenta.Sdk.Models.Data
{
    public class QuizLesson : Lesson
    {
        // table binded with lessonId
        public QuizData[] quizDatas { get; set; } = new QuizData[0];
    }
}
