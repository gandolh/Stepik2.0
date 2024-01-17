using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Licenta.UI.Components.Courses
{
    public partial class LessonPanel
    {
        private FullLessonDto? _fullLessonDto;

        [Parameter] public LessonDto? ActiveLessonSummarry { get; set; }
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            if(ActiveLessonSummarry != null)
            {
            _fullLessonDto = await HttpLicentaClient.GetOneLesson(ActiveLessonSummarry.Id);
            }
            await base.OnParametersSetAsync();
        }

        private void HandleRunCode()
        {

        }



        private string HelloWorldCppStr = """
                #include <iostream>

            int main() {
                std::cout << "Hello World!";
                return 0;
            }   


            """;
    }
}
