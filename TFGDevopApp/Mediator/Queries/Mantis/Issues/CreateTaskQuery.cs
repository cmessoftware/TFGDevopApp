using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Models.Mantis;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    internal class CreateTaskQuery : IRequest<ResultMessage<TaskResponseDto>>
    {
        private TaskRequestDto request;

        public CreateTaskQuery(TaskRequestDto request)
        {
            this.request = request;
        }
    }
}