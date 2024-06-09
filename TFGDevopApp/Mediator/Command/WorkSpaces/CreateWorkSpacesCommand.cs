using MediatR;
using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Command.WorkSpaces
{
    public class CreateWorkSpacesCommand : IRequest<ResultMessage<bool>>
    {
        public readonly WorkspaceRequestDto Workspace;

        public CreateWorkSpacesCommand(WorkspaceRequestDto workspace)
        {
            Workspace = workspace;
        }



    }
}
