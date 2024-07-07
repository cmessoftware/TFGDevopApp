using MediatR;
using TFGDevopsApp1.Core.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Issues;

namespace TFGDevopsApp1.Mediator.Command.Mantis
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