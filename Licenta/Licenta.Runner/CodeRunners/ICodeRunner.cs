using Licenta.SDK.Models.Dtos;

namespace Licenta.Runner.CodeRunners
{
    public interface ICodeRunner
    {
        public Task<CodeRunResult> Run(CodeRunReqDto req);
    }
}
