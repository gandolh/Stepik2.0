using Licenta.Sdk.Models.Data;

namespace Licenta.Runner.CodeRunners
{
    internal interface ICodeRunner
    {
        public CodeRunResult Run(CodeRunReq req);
    }
}
