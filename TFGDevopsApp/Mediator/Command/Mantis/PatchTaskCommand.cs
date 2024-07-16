using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Mediator.Command.Mantis
{
    public class PatchTaskCommand : IRequest<Result<TaskResponseDto>>
    {
        public TaskPatchRequestDto TaskPatchRequest = new();
        public readonly string Path;
        private readonly int ChangeSetId;

        public PatchTaskCommand(TaskPatchRequestDto request,
                                 string path)
                                
        {
            TaskPatchRequest.RelatedIssueId = request.RelatedIssueId;
            Path = path;
            ChangeSetId = request.ChangeSetId;
        }
    }
}