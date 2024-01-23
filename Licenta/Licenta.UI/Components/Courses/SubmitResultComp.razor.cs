
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Licenta.UI.Components.Courses
{
    public partial class SubmitResultComp
    {
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] public KafkaLicentaClient KafkaLicentaClient { get; set; } = default!;
        [Inject] public LicentaConfig LicentaConfig { get; set; } = default!;
        [Parameter] public FullExerciseDto Exercise { get; set; } = default!;
        [Parameter] public CodeLanguage Language { get; set; } 
        private List<SubmitResult> submitResults = [];

        internal async Task HandleSubmitCode()
        {
            submitResults = new List<SubmitResult>();
            string code = await JSRuntime.InvokeAsync<string>("Main.GetCode");

            foreach (var codeEval in Exercise.CodeEvaluationEntries)
            {
                CodeRunReqDto req = new CodeRunReqDto()
                {
                    Code = code,
                    Input = codeEval.Input,
                    Language = CodeLanguage.Cpp
                };

                string opId = await KafkaLicentaClient.RunCode(LicentaConfig.Kafka.Endpoints.RunCode, req, OnCodeRunned);
                submitResults.Add(new SubmitResult()
                {
                    OpId=opId,
                    evaluationEntryDto = codeEval
                });
            }
             
        }

        private async Task OnCodeRunned(KafkaDto dto)
        {
            KafkaLicentaClient.RemoveNotifier(LicentaConfig.Kafka.Endpoints.RunCode.Replace("Req", "Resp"),
                dto.OperationId);

            var codeResult = JsonSerializer.Deserialize<CodeRunResultDto>(dto.Body) ?? new();
            var index = submitResults.FindIndex(el => el.OpId == dto.OperationId);
            submitResults[index].resultDto = codeResult;
            await InvokeAsync(() => StateHasChanged());
        }

        public void Clear()
        {
            submitResults.Clear();
        }

        private bool ExpectedEqualsResult(SubmitResult submit)
        {
            return submit!.resultDto!.Result.Trim().Equals(submit.evaluationEntryDto.ExpectedResult.Trim());
        }
    }
}
