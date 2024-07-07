using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Issues;

namespace TFGDevopsApp1.Mediator.Queries.Mantis.Issues
{
    internal class UpdateTaskQuery : IRequest<Result<TaskResponseDto>>
    {
        private TaskCreateRequestDto request;

        public UpdateTaskQuery(TaskCreateRequestDto request)
        {
            this.request = request;
        }
    }
}