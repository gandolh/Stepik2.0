using Licenta.SDK.Models.Dtos;

namespace Licenta.Runner.CodeRunners
{
    internal class NullCodeRunner : ICodeRunner
    {
        public Task<CodeRunResult> Run(CodeRunReqDto req)
        {
            throw new NotImplementedException();
        }
    }
}
