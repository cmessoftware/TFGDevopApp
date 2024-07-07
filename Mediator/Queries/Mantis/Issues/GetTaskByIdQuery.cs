using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Issues;
using TFGDevopsApp1.Interfaces;

namespace TFGDevopsApp1.Mediator.Queries.Mantis.Issues
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