using Licenta.SDK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
