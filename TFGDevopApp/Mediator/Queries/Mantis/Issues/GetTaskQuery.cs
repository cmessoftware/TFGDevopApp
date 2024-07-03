using MediatR;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskQuery : IRequest<Result<TaskResponseDto>>
    {
        public string Path { get; internal set; }
        public GetTaskQuery(string path)
        {
            Path = path;
        }


    }
}