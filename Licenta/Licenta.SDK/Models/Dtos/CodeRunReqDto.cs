namespace Licenta.SDK.Models.Dtos
{
    public class CodeRunReqDto
    {
        public string Code { get; set; } = "";
        public string Input { get; set; } = "";
        public CodeLanguage Language { get; set; }
    }

    public enum CodeLanguage
    {
        Python,
        Cpp,
        Undefined
    }
}
