using MediatR;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskByIdQuery : IRequest<Result<TaskResponseDto>>
    {
        public GetTaskByIdQuery(string path, int id)
        {
            Id = id;
            Path = path;
        }

        public int Id { get; }
        public string Path { get; internal set; }
    }
}