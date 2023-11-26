using Licenta.Sdk.Models.Dtos;

namespace Licenta.Sdk.Models.Data
{
    public class QuizLesson : LessonDto
    {
        public QuizDataDto[] quizDatas { get; set; } = new QuizDataDto[0];
    }
}
