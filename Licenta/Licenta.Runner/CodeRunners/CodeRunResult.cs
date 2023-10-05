using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Runner.CodeRunners
{
    internal class CodeRunResult
    {
        public string Result { get; set; } = "";
        public string Error { get; set; } = "";
        public ErrorCodeStatus ErrorCode { get; set; }
    }

    public enum ErrorCodeStatus
    {
        OutOfMemory,
        OutOfTime

    }
}
