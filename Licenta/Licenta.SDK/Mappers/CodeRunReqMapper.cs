using Licenta.SDK.Data;
using Licenta.SDK.Dtos;

namespace Licenta.SDK.Mappers
{
    public sealed class CodeRunReqMapper : MapperBase<CodeRunReq, CodeRunReqDto>
    {
        public override CodeRunReq Map(CodeRunReqDto element)
        {
            return new CodeRunReq
            {
                Code = element.Code,
                Input = element.Input,
                Language = LangStringToEnum(element.Language)
            };
        }

        public override CodeRunReqDto Map(CodeRunReq element)
        {
            return new CodeRunReqDto
            {
                Code = element.Code,
                Input = element.Input,
                Language = LangEnumToString(element.Language)
            };
        }

        private string LangEnumToString(CodeLanguage lang)
        {
            return lang switch
            {
                CodeLanguage.Python => "PYTHON",
                CodeLanguage.Cpp => "CPP",
                _ => "UNDEFINED"
            };

        }

        private CodeLanguage LangStringToEnum(string lang) {
            return lang switch
            {
                "PYTHON" => CodeLanguage.Python,
                "CPP" => CodeLanguage.Cpp,
                _ => CodeLanguage.Undefined
            };
        }
    }
}
