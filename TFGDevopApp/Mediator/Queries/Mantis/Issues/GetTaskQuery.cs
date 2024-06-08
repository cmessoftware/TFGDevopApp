using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Models.Mantis;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskQuery : IRequest<ResultMessage<TaskResponseDto>>
    {
        public string Path { get; internal set; }
        public GetTaskQuery(string path)
        {
            Path = path;
        }


    }
}