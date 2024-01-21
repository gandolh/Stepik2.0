using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Data
{
    public class SubmitResult
    {
        public string OpId { get; set; } = string.Empty;
        public CodeRunResultDto? resultDto { get; set; }
        public required CodeEvaluationEntryDto evaluationEntryDto { get; set; }
    }
}
