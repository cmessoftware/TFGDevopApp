using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp.Mediator.Queries.Plastic.WorkSpaces
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