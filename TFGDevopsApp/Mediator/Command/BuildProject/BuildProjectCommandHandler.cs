using MediatR;
using System.Diagnostics;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Build;
using TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject;

namespace TFGDevopsApp.UseCases.Contributor.Command.CompileProyects
{
    internal class BuildProjectCommandHandler : IRequestHandler<BuildProjectCommand, Result<BuildResponseDto>>
    {


        public async Task<Result<BuildResponseDto>> Handle(BuildProjectCommand request, CancellationToken cancellationToken)
        {
            var projectPath = request.ProjectPath;
            string outputDirectory = string.Empty;
            string buildId = string.Empty;


            var projectFiles = Directory.GetFiles(projectPath, "*.sln", SearchOption.AllDirectories);
            if (projectFiles.Length == 0)
            {
                return await Task.FromResult(new Result<BuildResponseDto>
                {
                    Message = $"No se encontraron soluciones .NET en el directorio especificado {projectPath}",
                    Success = false
                });
            }

            foreach (var projectFile in projectFiles)
            {
                outputDirectory = $"{ Path.Combine(request.ProjectPath, request.PathToCompile, "Compilados")}";
                buildId = Guid.NewGuid().ToString()[..8];


                outputDirectory += $@"\{buildId}_{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                                        .Replace(" ","-")
                                        .Replace(":","-")
                                        .Replace("-", "_")}";

                outputDirectory = $"\"{outputDirectory}\"";

         
                Console.WriteLine($"Compilando: {projectFile} en {outputDirectory}");

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "dotnet",
                        Arguments = $@"build -c Release -o {outputDirectory}",
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
                    return await Task.FromResult(new Result<BuildResponseDto>
                    {
                        Message = $"Error: {output}",
                        Success = false,
                        Data = new BuildResponseDto
                        {
                            BuildStatus = EnumStatus.Error
                        }
                    });
                }

            }

            return await Task.FromResult(new Result<BuildResponseDto>
            {
                Message = "Proyecto compilado correctamente.",
                Success = true,
                Data = new BuildResponseDto
                {
                    BuildStatus = EnumStatus.Success,
                    OutputDirectory = outputDirectory,
                    BuildDate = DateTime.Now,
                    BuildId = Guid.NewGuid().ToString()
                }
            });
        }
    }
}
