using MediatR;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.UseCases.Contributor.Command.CompileProyects
{
    public class CloneProjectCommand : IRequest<Result<string>>
    {
        public string SourceRepositoryUrl { get; set; }
        public string DstRepositoryUrl { get; set; }
        public string ScriptPath { get; set; }
        public string WorkplacePath { get; set; }
    }
}
