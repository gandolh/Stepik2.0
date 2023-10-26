using Licenta.Sdk.Models.Data;

namespace Licenta.Runner.CodeRunners
{
    internal class NullCodeRunner : ICodeRunner
    {
        public Task<CodeRunResult> Run(CodeRunReq req)
        {
            throw new NotImplementedException();
        }
    }
}
