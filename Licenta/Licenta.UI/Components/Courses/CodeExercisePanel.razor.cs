using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace Licenta.UI.Components.Courses
{
    public partial class CodeExercisePanel
    {
        [Parameter] public required ExerciseDto Exercise { get; set; }
        [Inject] public KafkaLicentaClient KafkaLicentaClient { get; set; } = default!;
        [Inject] public LicentaConfig LicentaConfig { get; set; } = default!;

        private CodeLanguage _selectedLanguage { get; set; }
        private string _code { get; set; } = CodeSamplers.CppStartCode;
        private string _customInput { get; set; } = string.Empty;
        private CodeRunResultDto? _codeResult;

        protected override Task OnParametersSetAsync()
        {
            _customInput = Exercise.SampleInput;
            return base.OnParametersSetAsync();
        }

        private async Task HandleRunCode()
        {
            CodeRunReqDto req = new CodeRunReqDto()
            {
                Code = _code,
                Input = _customInput,
                Language = _selectedLanguage
            };
            await KafkaLicentaClient.RunCode(LicentaConfig.Kafka.Endpoints.RunCode, req, OnCodeRunned);
        }

        private async Task OnCodeRunned(KafkaDto dto)
        {
            KafkaLicentaClient.RemoveNotifier(LicentaConfig.Kafka.Endpoints.RunCode.Replace("Req", "Resp"),
                dto.OperationId);

            _codeResult = JsonSerializer.Deserialize<CodeRunResultDto>(dto.Body) ?? new();

            await InvokeAsync(() => StateHasChanged());
        }

        private async Task HandleSubmitCode()
        {
            await Task.CompletedTask;
        }
    }
}
