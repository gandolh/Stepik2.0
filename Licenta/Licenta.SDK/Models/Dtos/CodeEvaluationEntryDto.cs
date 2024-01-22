namespace Licenta.SDK.Models.Dtos
{
    public class CodeEvaluationEntryDto : IDtoWithId
    {
        public int Id { get; set; } 
        public string Input { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
}
