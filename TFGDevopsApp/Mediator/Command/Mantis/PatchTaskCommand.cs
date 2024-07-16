using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Mediator.Command.Mantis
{
    public class PatchTaskCommand : IRequest<Result<TaskTrackingResponseDto>>
    {
        public TaskPatchRequestDto TaskPatchRequest = new();
        public readonly string Path;
        private readonly int ChangeSetId;

        public PatchTaskCommand(TaskPatchRequestDto request,
                                 string path)
                                
        {
            TaskPatchRequest = request;
            Path = path;
            ChangeSetId = request.ChangeSetId;
        }
    }
}