using Licenta.SDK.Models.Dtos;
using System.Diagnostics;

namespace Licenta.Runner.CodeRunners
{
    public class CppCodeRunner : ICodeRunner
    {
        public async Task<CodeRunResultDto> Run(CodeRunReqDto req)
        {
            Directory.CreateDirectory("/code_to_run");

            string filename = Guid.NewGuid().ToString();
            string cppPath = "/code_to_run/" + filename + "_cpp.cpp";
            string outPath = "/code_to_run/" + filename + "_cpp.out";

            await Compile(cppPath, outPath, req.Code);
            return await RunCompilled(outPath, req.Input);
        }
        private async Task<CodeRunResultDto> RunCompilled(string outPath, string InputData)
        {
            ProcessStartInfo processStartInfo = new()
            {
                FileName = outPath,
                //Arguments = outPath,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process process = new()
            {
                StartInfo = processStartInfo
            };
            process.Start();
            if (string.IsNullOrEmpty(InputData) == false)
            {
                string[] inputs = InputData.Split("\n");
                foreach (string input in inputs)
                    process.StandardInput.WriteLine(input);
            }
            string result = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();
            process.StandardInput.Close();
            await process.WaitForExitAsync();
            File.Delete(outPath);

            Console.WriteLine("error: " + error);
            Console.WriteLine("result: " + result);

            return new CodeRunResultDto()
            {
                Result = result,
                Error = error,
                ErrorCode = string.IsNullOrEmpty(error) ?
                    ErrorCodeStatus.NoError : ErrorCodeStatus.UnknownError
            };
        }
        private async Task Compile(string cppPath, string outPath, string code)
        {
            string command = $"g++";
            string processArgument = $"{cppPath} -o {outPath}";

            await File.WriteAllTextAsync(cppPath, code);
            ProcessStartInfo processStartInfo = new()
            {
                FileName = command,
                Arguments = processArgument,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process process = new()
            {
                StartInfo = processStartInfo
            };
            process.Start();
            string compilleError = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();
            File.Delete(cppPath);


            Console.WriteLine("error: " + compilleError);
            if (string.IsNullOrEmpty(compilleError) == false)
                throw new ArgumentException("Couldn't compille: %s", compilleError);
        }
    }
}
