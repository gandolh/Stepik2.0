namespace Licenta.Sdk.Models.Data
{
    public class CodeRunReq
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
