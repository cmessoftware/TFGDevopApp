using MediatR;
using System.IO;
using TFGDevopsApp.Core.Models;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject;

namespace TFGDevopsApp.UseCases.Contributor.Command.CompileProyects
{
    internal class CodeReviewCommandHandler : IRequestHandler<CodeReviewCommand, ResultMessage<CodeFileModel>>
    {

        public async Task<ResultMessage<CodeFileModel>> Handle(CodeReviewCommand request, CancellationToken cancellationToken)
        {
            var projectPath = request.ProjectPath;


            var codeFiles = Directory.GetFiles(projectPath, request.IncludeFiles, SearchOption.AllDirectories);
            if (codeFiles.Length == 0)
            {
                return await Task.FromResult(new ResultMessage<CodeFileModel>
                {
                    Message = $"No se encontraron archivo de código en {projectPath}",
                    Success = false,
                });
            }

            if (codeFiles.Select(x => x == request.ProjectPath).FirstOrDefault())
            {
                var code = File.ReadAllText(request.ProjectPath);

                return await Task.FromResult(new ResultMessage<CodeFileModel>
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

            return await Task.FromResult(new ResultMessage<CodeFileModel>
            {
                Message = "Archivo cargado correctamente",
                Success = true
            });
        }
    }
}
