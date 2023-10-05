using Licenta.SDK.Data;

namespace Licenta.Runner.CodeRunners
{
    internal interface ICodeRunner
    {
        public CodeRunResult Run(CodeRunReq req);
    }
}
