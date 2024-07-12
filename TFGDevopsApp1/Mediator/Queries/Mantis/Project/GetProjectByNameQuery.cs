using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Interfaces;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Project
{
    public class GetProjectByNameQuery : IRequest<Result<TaskProjectResponseDto>>
    {
        public GetProjectByNameQuery(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string Name { get; }
        public string Path { get; internal set; }
    }
}