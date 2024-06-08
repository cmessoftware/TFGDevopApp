using MediatR;
using System.Diagnostics;
using System.IO;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject;

namespace TFGDevopsApp.UseCases.Contributor.Command.CompileProyects
{
    internal class BuildProjectCommandHandler : IRequestHandler<BuildProjectCommand, ResultMessage<string>>
    {


        public async Task<ResultMessage<string>> Handle(BuildProjectCommand request, CancellationToken cancellationToken)
        {
            var projectPath = Path.Combine(request.PathToCompile, request.RepositoryName);


            var projectFiles = Directory.GetFiles(projectPath, "*.csproj", SearchOption.AllDirectories);
            if (projectFiles.Length == 0)
            {
                return await Task.FromResult(new ResultMessage<string>
                {
                    Message = $"No se encontraron proyectos .NET en el directorio especificado {projectPath}",
                    Success = false
                });
            }

            foreach (var projectFile in projectFiles)
            {
                var pathToCompile = request.PathToCompile;
                var outputDirectory = Path.Combine(pathToCompile, request.RepositoryName, "Compilado");

                if (!Directory.Exists(outputDirectory))
                    Directory.CreateDirectory(outputDirectory);

                Console.WriteLine($"Compilando: {projectFile} en {outputDirectory}");

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "dotnet",
                        Arguments = $@"build {projectFile} -o {outputDirectory}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine(output);

                if (process.ExitCode != 0)
                {
                    return await Task.FromResult(new ResultMessage<string>
                    {
                        Message = $"Error: {output}",
                        Success = false
                    });
                }

            }

            return await Task.FromResult(new ResultMessage<string>
            {
                Message = "Proyecto compilado correctamente.",
                Success = true
            });
        }
    }
}
