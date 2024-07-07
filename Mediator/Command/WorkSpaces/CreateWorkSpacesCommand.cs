using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dto.Plastic.Workspaces;

namespace TFGDevopsApp1.Mediator.Command.WorkSpaces
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
