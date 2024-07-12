using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
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