using MediatR;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    internal class UpdateTaskQuery : IRequest<Result<TaskResponseDto>>
    {
        private TaskRequestDto request;

        public UpdateTaskQuery(TaskRequestDto request)
        {
            this.request = request;
        }
    }
}