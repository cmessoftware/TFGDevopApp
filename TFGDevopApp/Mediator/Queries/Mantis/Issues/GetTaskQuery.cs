using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
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