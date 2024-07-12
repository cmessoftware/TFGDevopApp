using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp.Mediator.Command.WorkSpaces
{
    public class UpdateWorkSpacesCommand : IRequest<Result<bool>>
    {
        public readonly EditWorkspaceRequestDto Workspace;

        public UpdateWorkSpacesCommand(EditWorkspaceRequestDto workspace)
        {
            Workspace = workspace;
        }
    }
}