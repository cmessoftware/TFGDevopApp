using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Issues;

namespace TFGDevopsApp1.Mediator.Queries.Mantis.Issues
{
    public class GetTaskQuery : IRequest<Result<TasksResponseDto>>
    {
        public string Path { get; internal set; }
        public GetTaskQuery(string path)
        {
            Path = path;
        }


    }
}