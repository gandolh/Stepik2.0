using Confluent.Kafka;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Licenta.UI.Components.Courses
{
    public partial class LessonPanel
    {
        private FullLessonDto? _fullLessonDto;

        [Parameter] public LessonDto? ActiveLessonSummarry { get; set; }
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] public KafkaLicentaClient KafkaLicentaClient { get; set; } = default!;
        [Inject] public LicentaConfig LicentaConfig { get; set; } = default!;


        private CodeLanguage _selectedLanguage { get; set; }
        private string _code { get; set; } = CodeSamplers.CppStartCode;
        private string _customInput { get; set; } = string.Empty;
        private CodeRunResultDto? _codeResult;


        protected override async Task OnParametersSetAsync()
        {
            if(ActiveLessonSummarry != null)
            {
                _fullLessonDto = await HttpLicentaClient.GetOneLesson(ActiveLessonSummarry.Id);
            }
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync("Main.initializeFormSelect");
            await base.OnAfterRenderAsync(firstRender);
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
            KafkaLicentaClient.RemoveNotifier(LicentaConfig.Kafka.Endpoints.RunCode.Replace("Req","Resp"),
                dto.OperationId);

            _codeResult = JsonSerializer.Deserialize<CodeRunResultDto>(dto.Body) ?? new();
                
            await InvokeAsync(()=> StateHasChanged());
        }

        private async Task HandleSubmitCode()
        {
            await Task.CompletedTask;
        }

        
    }
}
