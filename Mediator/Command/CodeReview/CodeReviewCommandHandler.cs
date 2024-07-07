using MediatR;
using System.IO;
using TFGDevopsApp1.Core.Models;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.UseCases.Contributor.Command.CodeReviewProject;

namespace TFGDevopsApp1.UseCases.Contributor.Command.CompileProyects
{
    internal class CodeReviewCommandHandler : IRequestHandler<CodeReviewCommand, Result<CodeFileModel>>
    {

        public async Task<Result<CodeFileModel>> Handle(CodeReviewCommand request, CancellationToken cancellationToken)
        {
            var projectPath = request.ProjectPath;


            var codeFiles = Directory.GetFiles(projectPath, request.IncludeFiles, SearchOption.AllDirectories);
            if (codeFiles.Length == 0)
            {
                return await Task.FromResult(new Result<CodeFileModel>
                {
                    Message = $"No se encontraron archivo de código en {projectPath}",
                    Success = false,
                });
            }

            if (codeFiles.Select(x => x == request.ProjectPath).FirstOrDefault())
            {
                var code = File.ReadAllText(request.ProjectPath);

                return await Task.FromResult(new Result<CodeFileModel>
                {
                    Success = true,
                    Data = new CodeFileModel
                    {
                        CodeContent = code,
                        Path = request.ProjectPath,
                        Type = Path.GetExtension(request.ProjectPath),
                    }
                });

            }

            return await Task.FromResult(new Result<CodeFileModel>
            {
                Message = "Archivo cargado correctamente",
                Success = true
            });
        }
    }
}
