using MediatR;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Services.Contributor.Command.SCM.WorkSpaces
{
    public class GetRepositoriesCommand : IRequest<ResultMessage<string>>
    {


    }
}
