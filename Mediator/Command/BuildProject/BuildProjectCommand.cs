using MediatR;
using TFGDevopsApp1.Core.Models.Result;

namespace TFGDevopsApp1.UseCases.Contributor.Command.CodeReviewProject
{
    public class BuildProjectCommand : IRequest<Result<string>>
    {
        public string RepositoryName { get; set; }
        public string WorkplacePath { get; set; }
        public string PathToCompile { get; set; }
    }
}
