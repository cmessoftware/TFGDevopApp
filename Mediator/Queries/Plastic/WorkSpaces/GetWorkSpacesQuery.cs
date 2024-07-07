using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp1.Mediator.Queries.Plastic.WorkSpaces
{
    public class GetWorkSpacesQuery : IRequest<Result<List<WorkspaceResponseDto>>>
    {
        public string Path;

        public GetWorkSpacesQuery(string path)
        {
            Path = path;
        }
    }
}