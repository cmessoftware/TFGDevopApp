using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Mediator.Command.Mantis
{
    public class CreateTaskCommand : IRequest<Result<TaskCreateResponseDto>>
    {
        public readonly Issue Issue;
        public readonly string Path;

        public CreateTaskCommand(TaskCreateRequestDto request,
                                 string path)
        {
            Issue = request.Issue;
            this.Path = path;
        }
    }
}