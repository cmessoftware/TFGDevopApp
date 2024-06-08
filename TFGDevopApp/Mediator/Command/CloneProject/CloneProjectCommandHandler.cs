using MediatR;
using System.Diagnostics;
using System.IO;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.UseCases.Contributor.Command.CompileProyects
{
    internal class CloneProjectCommandHandler : IRequestHandler<CloneProjectCommand, ResultMessage<string>>
    {


        public Task<ResultMessage<string>> Handle(CloneProjectCommand request, CancellationToken cancellationToken)
        {

            Console.WriteLine($"Clonando: {request.SourceRepositoryUrl} en {request.DstRepositoryUrl}");

            Directory.SetCurrentDirectory(request.ScriptPath);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cloneRepo.bat",
                    Arguments = $@"{request.SourceRepositoryUrl} {request.DstRepositoryUrl} >> log.{DateTime.Now.Ticks}.txt",
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
                return Task.FromResult(new ResultMessage<string>
                {
                    Message = $"Error en el clonado del repositorio {request.SourceRepositoryUrl}.",
                    Success = false
                });

            }

            return Task.FromResult(new ResultMessage<string>
            {
                Message = $"Clonando: {request.SourceRepositoryUrl} en {request.DstRepositoryUrl} exitoso",
                Success = true
            });

        }
    }
}
