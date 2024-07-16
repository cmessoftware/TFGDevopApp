using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Mediator.Command.Mantis
{
    public class GetIssueTrackingByChangeSetIdCommand : IRequest<Result<IssueTrackingResponseDto>>
    {
        public int ChangeSetId { get; }
  
        public GetIssueTrackingByChangeSetIdCommand(int changeSetId)
        {
            ChangeSetId = changeSetId;
        }

    }
}