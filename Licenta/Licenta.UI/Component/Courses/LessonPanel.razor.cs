using Components.UI;
using Confluent.Kafka;
using Licenta.SDK.Models.Dtos;
using Licenta.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Licenta.UI.Component.Courses
{
    public partial class LessonPanel : BaseLicentaComp
    {
        [Parameter] public FullLessonDto? ActiveLessonSummarry { get; set; }
        [Inject] public HttpLicentaClient HttpLicentaClient { get; set; } = default!;
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;
    
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.initializeFormSelect");
            await base.OnAfterRenderAsync(firstRender);
        }

       

        
    }
}
