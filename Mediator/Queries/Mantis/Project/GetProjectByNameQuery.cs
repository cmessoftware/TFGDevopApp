using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Interfaces;

namespace TFGDevopsApp1.Mediator.Queries.Mantis.Project
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