using MediatR;
using TFGDevopsApp1.Core.Models.Result;

namespace TFGDevopsApp1.UseCases.Contributor.Command.CompileProyects
{
    public class CloneProjectCommand : IRequest<Result<string>>
    {
        public string SourceRepositoryUrl { get; set; }
        public string DstRepositoryUrl { get; set; }
        public string ScriptPath { get; set; }
        public string WorkplacePath { get; set; }
    }
}
