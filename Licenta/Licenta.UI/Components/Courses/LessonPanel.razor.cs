using Components.UI;
using Confluent.Kafka;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Licenta.UI.Components.Courses
{
    public partial class LessonPanel : BaseLicentaComp
    {
        private FullLessonDto? _fullLessonDto;

        [Parameter] public LessonDto? ActiveLessonSummarry { get; set; }
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;
    
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

       

        
    }
}
