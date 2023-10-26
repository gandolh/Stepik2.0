using Licenta.Sdk.Models.Data;

namespace Licenta.Runner.CodeRunners
{
    public interface ICodeRunner
    {
        public Task<CodeRunResult> Run(CodeRunReq req);
    }
}
