using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Models.Mantis;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    internal class UpdateTaskQuery : IRequest<ResultMessage<TaskResponseDto>>
    {
        private TaskRequestDto request;

        public UpdateTaskQuery(TaskRequestDto request)
        {
            this.request = request;
        }
    }
}