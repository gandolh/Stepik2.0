using Licenta.Runner.CodeRunners;
using Licenta.Sdk.Models.Data;

namespace Licenta.Runner.Tests
{
    public class CodeRunner
    {
        [Fact]
        public void RunCppCode()
        {
            ICodeRunner codeRunner = new CppCodeRunner();
            CodeRunResult resp = codeRunner.Run(new CodeRunReq()
            {
                Code = """
                #include <iostream>

                int main() {
                    std::cout << "Hello World!";
                    return 0;
                }
                """,
                Input = """

                """
            });
        }

        [Fact]
        public void RunPythonCode()
        {
            ICodeRunner codeRunner = new PythonCodeRunner();
            CodeRunResult resp = codeRunner.Run(new CodeRunReq()
            {
                Code = """
                print("This line will  be printed.")
                """,
                Input = """

                """
            });
        }
    }
}