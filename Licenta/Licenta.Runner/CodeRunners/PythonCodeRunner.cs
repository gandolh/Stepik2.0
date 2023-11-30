using Licenta.SDK.Models.Dtos;
using System.Diagnostics;

namespace Licenta.Runner.CodeRunners
{
    public class PythonCodeRunner : ICodeRunner
    {
        public async Task<CodeRunResult> Run(CodeRunReqDto req)
        {
            string path = "/code_to_run/" + Guid.NewGuid().ToString() + "_script.py";
            string command = $"python3";

            Directory.CreateDirectory("/code_to_run");
            await File.WriteAllTextAsync(path, req.Code);
            ProcessStartInfo processStartInfo = new()
            {
                FileName = command,
                Arguments = path,
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
            if(string.IsNullOrEmpty(req.Input) == false)
            {
                string[] inputs = req.Input.Split("\n");
                foreach(string input in inputs)
                    process.StandardInput.WriteLine(input);
            }
            string result = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();
            process.StandardInput.Close();
            await process.WaitForExitAsync();
            File.Delete(path);

            Console.WriteLine("error: " + error);
            Console.WriteLine("result: " + result);

            return new CodeRunResult()
            {
                Result = result,
                Error = error
            };
        }
    }
}
