using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Mediator.Command.MantisBT;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<Issue>>
    {
        Task<Result<Issue>> IRequestHandler<CreateTaskCommand, Result<Issue>>.Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}