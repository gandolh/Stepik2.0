using Components.UI;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Data;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Licenta.UI.Component.Courses
{
    public partial class CodeExercisePanel : BaseLicentaComp
    {
        [Parameter] public required FullExerciseDto Exercise { get; set; }
        [Inject] public KafkaLicentaClient KafkaLicentaClient { get; set; } = default!;
        [Inject] public LicentaConfig LicentaConfig { get; set; } = default!;
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

        private CodeLanguage _selectedLanguage { get; set; }

        private string _customInput { get; set; } = string.Empty;
        private CodeRunResultDto? _codeResult;
        private SubmitResultComp submitResultComp = default!;

        protected override Task OnParametersSetAsync()
        {
            _customInput = Exercise.SampleInput;
            return base.OnParametersSetAsync();
        }

        private async Task HandleRunCode()
        {
            string code = await JSRuntime.InvokeAsync<string>("Main.GetCode");

            CodeRunReqDto req = new CodeRunReqDto()
            {
                Code = code,
                Input = _customInput,
                Language = _selectedLanguage
            };
            await KafkaLicentaClient.RunCode(LicentaConfig.Kafka.Endpoints.RunCode, req, OnCodeRunned);
        }

        private async Task OnCodeRunned(KafkaDto dto)
        {
            submitResultComp.Clear();
            KafkaLicentaClient.RemoveNotifier(LicentaConfig.Kafka.Endpoints.RunCode.Replace("Req", "Resp"),
                dto.OperationId);

            _codeResult = JsonSerializer.Deserialize<CodeRunResultDto>(dto.Body) ?? new();

            await InvokeAsync(() => StateHasChanged());
        }

        private async void OnSubmitCode()
        {
            _codeResult = null;
           await submitResultComp.HandleSubmitCode();
        }
    }
}
