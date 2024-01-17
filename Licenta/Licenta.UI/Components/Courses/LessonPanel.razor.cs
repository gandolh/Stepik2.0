using Confluent.Kafka;
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
        [Inject] public KafkaLicentaClient KafkaLicentaClient { get; set; } = default!;
        [Inject] public LicentaConfig LicentaConfig { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            if(ActiveLessonSummarry != null)
            {
            _fullLessonDto = await HttpLicentaClient.GetOneLesson(ActiveLessonSummarry.Id);
            }
            await base.OnParametersSetAsync();
        }

        private async Task HandleRunCode()
        {
            CodeRunReqDto req = new CodeRunReqDto()
            {
                Code = HelloWorldCppStr,
                Input = "",
                Language = CodeLanguage.Cpp
            };
            await KafkaLicentaClient.RunCode(LicentaConfig.Kafka.Endpoints.RunCode, req, OnCodeRunned);
        }

        private async Task OnCodeRunned(KafkaDto dto)
        {
            KafkaLicentaClient.RemoveNotifier(LicentaConfig.Kafka.Endpoints.RunCode.Replace("Req","Resp"),
                dto.OperationId);

            await Task.CompletedTask;
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
