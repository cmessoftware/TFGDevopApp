using MediatR;
using TFGDevopsApp.Core.Models;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject
{
    public class CodeReviewCommand : IRequest<ResultMessage<CodeFileModel>>
    {
        public string RepositoryName { get; set; }
        public string CodeFileName { get; set; }
        public string ProjectPath { get; set; }

        public string IncludeFiles { get; set; }
    }
}
