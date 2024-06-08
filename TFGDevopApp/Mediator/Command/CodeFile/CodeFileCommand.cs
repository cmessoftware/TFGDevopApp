using MediatR;
using TFGDevopsApp.Core.Models;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.UseCases.Contributor.Command.CodeReviewProject
{
    public class CodeFileCommand : IRequest<ResultMessage<CodeFileModel>>
    {
        public string CodeFileName { get; set; }
        public string ProjectPath { get; set; }
    }
}
