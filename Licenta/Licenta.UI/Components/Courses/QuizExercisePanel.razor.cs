using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Courses
{
    public partial class QuizExercisePanel
    {
        [Parameter] public required ExerciseDto Exercise { get; set; }
        private int _selectedIndex = 0;
        private bool? isCorect = null;

        private void HandleCheckQuiz()
        {
            isCorect = (Exercise.QuizVariants[_selectedIndex].IsCorrect == true);
        }

        private void ChangeSelected(int index) {
            _selectedIndex = index;
        }
    }
}
