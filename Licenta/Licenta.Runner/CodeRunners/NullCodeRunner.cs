using Licenta.Sdk.Models.Data;

namespace Licenta.Runner.CodeRunners
{
    internal class NullCodeRunner : ICodeRunner
    {
        public CodeRunResult Run(CodeRunReq req)
        {
            throw new NotImplementedException();
        }
    }
}
