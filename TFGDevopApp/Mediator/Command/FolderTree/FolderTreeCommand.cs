using MediatR;
using TFGDevopsApp.Core.Models.FolderTree;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject
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
