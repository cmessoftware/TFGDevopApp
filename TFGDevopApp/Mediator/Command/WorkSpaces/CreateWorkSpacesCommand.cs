using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dto.Plastic.Workspaces;

namespace TFGDevopsApp.Mediator.Command.WorkSpaces
{
    public class CreateWorkSpacesCommand : IRequest<Result<bool>>
    {
        public readonly WorkspaceRequestDto Workspace;

        public CreateWorkSpacesCommand(WorkspaceRequestDto workspace)
        {
            Workspace = workspace;
        }
    }
}
