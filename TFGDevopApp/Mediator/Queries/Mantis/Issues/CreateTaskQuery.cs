using MediatR;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    internal class CreateTaskQuery : IRequest<Result<TaskResponseDto>>
    {
        private TaskRequestDto request;

        public CreateTaskQuery(TaskRequestDto request)
        {
            this.request = request;
        }
    }
}