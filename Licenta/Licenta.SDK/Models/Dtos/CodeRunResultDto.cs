namespace Licenta.SDK.Models.Dtos
{
    public class CodeRunResultDto
    {
        public string Result { get; set; } = "";
        public string Error { get; set; } = "";
        public ErrorCodeStatus ErrorCode { get; set; }
    }

    public enum ErrorCodeStatus
    {
        NoError,
        OutOfMemory,
        OutOfTime,
        UnknownError

    }
}
