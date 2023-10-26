using Licenta.Runner.CodeRunners;
using Licenta.Sdk.Models.Data;

//var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddHostedService<RunnerService>();

//var host = builder.Build();
//host.Run();

ICodeRunner pythonRunner = new PythonCodeRunner();

var x = await pythonRunner.Run(new CodeRunReq()
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
});


//ICodeRunner cppCodeRunner = new CppCodeRunner();
//cppCodeRunner.Run(new CodeRunReq()
//{
//    Code = """
//            #include <iostream>
//            int main() {
//                std::cout << "Hello World!";
//                return 0;
//            }
//            """,
//    Input = "",
//     Language = CodeLanguage.Cpp
//});