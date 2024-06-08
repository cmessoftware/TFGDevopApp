using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Models.Mantis;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskByIdQuery : IRequest<ResultMessage<TaskResponseDto>>
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