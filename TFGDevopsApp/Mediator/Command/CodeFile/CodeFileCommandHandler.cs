using MediatR;
using System.IO;
using TFGDevopsApp.Core.Models;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject;

namespace TFGDevopsApp.UseCases.Contributor.Command.CompileProyects
{
    public class CodeFileCommandHandler : IRequestHandler<CodeFileCommand, Result<CodeFileModel>>
    {
        private readonly IConfiguration _configuration;

        public CodeFileCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<Result<CodeFileModel>> Handle(CodeFileCommand request, CancellationToken cancellationToken)
        {
            var projectPath = request.ProjectPath;
            var patterns = _configuration["profiles:TFGDevopsApp.Web:environmentVariables:includeFiles"];
            var searchPatterns = string.IsNullOrEmpty(patterns) ? new List<string> { "*.cs" } :
                                 patterns.Split(",").ToList();
            var codeFiles = Directory.GetFiles(projectPath, @"*.cs|*.cshtml", SearchOption.AllDirectories);

            if (codeFiles.Length == 0)
            {
                return await Task.FromResult(new Result<CodeFileModel>
                {
                    Message = $"No se encontraron archivo de código en {projectPath}",
                    Success = false,
                });
            }


            return await Task.FromResult(new Result<CodeFileModel>
            {
                Message = "Estura de directorios del proyecyo cargado correctamente",
                Success = true,

            });

        }
    }
}
