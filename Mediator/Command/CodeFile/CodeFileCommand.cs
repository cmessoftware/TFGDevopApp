using MediatR;
using TFGDevopsApp1.Core.Models;
using TFGDevopsApp1.Core.Models.Result;

namespace TFGDevopsApp1.UseCases.Contributor.Command.CodeReviewProject
{
    public class CodeFileCommand : IRequest<Result<CodeFileModel>>
    {
        public string CodeFileName { get; set; }
        public string ProjectPath { get; set; }
    }
}
