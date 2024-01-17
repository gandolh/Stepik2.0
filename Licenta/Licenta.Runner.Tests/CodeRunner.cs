using Licenta.Runner.CodeRunners;
using Licenta.SDK.Models.Dtos;

namespace Licenta.Runner.Tests
{
    public class CodeRunner
    {
        CodeRunReqDto cppCodeTest = new CodeRunReqDto()
        {
            Code = """
            #include <iostream>

            // Function to sum two numbers
            int addNumbers(int a, int b) {
                return a + b;
            }

            int main() {
                int num1, num2;

                // Read two integer variables from the user
                std::cout << "Enter the first number: ";
                std::cin >> num1;

                std::cout << "Enter the second number: ";
                std::cin >> num2;

                // Call the function and store the result in a variable
                int result = addNumbers(num1, num2);

                // Print the result
                std::cout << "The sum of " << num1 << " + " << num2 << " = " << result << std::endl;

                return 0;
            }
            """,
            Input = "2\n3",
            Language = CodeLanguage.Cpp
        };
        CodeRunReqDto pythonCodeTest = new CodeRunReqDto()
        {
            Code = """
            # Define a function to sum two numbers
            def add_numbers(a, b):
                return a + b

            # Declare two integer variables
            num1 = int(input("Enter the first number: "))
            num2 = int(input("Enter the second number: "))

            # Call the function and store the result in a variable
            result = add_numbers(num1, num2)

            # Print the result
            print(f"{num1} + {num2} = {result}")

            """,
            Input = "2\n3",
            Language = CodeLanguage.Python
        };


        [Fact]
        public async Task RunCppCode()
        {
            ICodeRunner codeRunner = new CppCodeRunner();
            CodeRunResultDto resp = await codeRunner.Run(cppCodeTest);
            Assert.Empty(resp.Error);
        }

        [Fact]
        public async Task RunPythonCode()
        {
            ICodeRunner codeRunner = new PythonCodeRunner();
            CodeRunResultDto resp = await codeRunner.Run(pythonCodeTest);
            Assert.Empty(resp.Error);
        }
    }
}