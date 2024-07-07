using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp1.Mediator.Queries.Plastic.WorkSpaces
{
    public class GetWorkSpaceQuery : IRequest<Result<WorkspaceResponseDto>>
    {
        public GetWorkSpaceQuery(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public string Path { get;  set; }
        public string Name { get;  set; }
    }
}