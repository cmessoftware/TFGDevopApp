using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Build;

namespace TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject
{
    public class BuildProjectCommand : IRequest<Result<BuildResponseDto>>
    {

        public BuildProjectCommand(string projectPath, 
                                   string pathToCompile)
        {
            ProjectPath = projectPath;
            PathToCompile = pathToCompile;
        }

        public string ProjectPath { get; set; }
        public string WorkplacePath { get; set; }
        public string PathToCompile { get; set; }
    }
}
