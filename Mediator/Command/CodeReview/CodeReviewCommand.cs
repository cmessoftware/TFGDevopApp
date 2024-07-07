using MediatR;
using TFGDevopsApp1.Core.Models;
using TFGDevopsApp1.Core.Models.Result;

namespace TFGDevopsApp1.UseCases.Contributor.Command.CodeReviewProject
{
    public class CodeReviewCommand : IRequest<Result<CodeFileModel>>
    {
        public string RepositoryName { get; set; }
        public string CodeFileName { get; set; }
        public string ProjectPath { get; set; }

        public string IncludeFiles { get; set; }
    }
}
