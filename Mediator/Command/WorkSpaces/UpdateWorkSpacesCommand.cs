using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp1.Mediator.Command.WorkSpaces
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