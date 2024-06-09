using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp.Mediator.Queries.Plastic.WorkSpaces
{
    public class GetWorkSpacesQuery : IRequest<ResultMessage<List<WorkspaceResponseDto>>>
    {
        public string Path;

        public GetWorkSpacesQuery(string path)
        {
            Path = path;
        }
    }
}