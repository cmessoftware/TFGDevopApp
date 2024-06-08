using MediatR;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject
{
    public class BuildProjectCommand : IRequest<ResultMessage<string>>
    {
        public string RepositoryName { get; set; }
        public string WorkplacePath { get; set; }
        public string PathToCompile { get; set; }
    }
}
