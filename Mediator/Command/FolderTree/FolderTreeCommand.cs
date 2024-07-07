using MediatR;
using TFGDevopsApp1.Core.Models.FolderTree;
using TFGDevopsApp1.Core.Models.Result;

namespace TFGDevopsApp1.UseCases.Contributor.Command.CodeReviewProject
{
    public class FolderTreeCommand : IRequest<Result<FolderTreeDto>>
    {
        public string RepositoryName { get; set; }
        public string ProjectPath { get; set; }
        public List<string> ExcludePaths { get; set; }
        public string? IncludePaths { get; set; }

        public string TreeContent { get; set; }
    }
}
