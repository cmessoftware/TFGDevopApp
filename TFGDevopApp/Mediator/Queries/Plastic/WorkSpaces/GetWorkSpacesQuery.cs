using MediatR;
using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;

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