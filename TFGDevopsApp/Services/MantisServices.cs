using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Category;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Dtos.Mantis.Project;
using TFGDevopsApp.Interfaces;
using TFGDevopsApp.Mediator.Command.Mantis;
using TFGDevopsApp.Mediator.Queries.Mantis.Issues;
using TFGDevopsApp.Mediator.Queries.Mantis.Project;


namespace TFGDevopsApp.Services
{
    public class MantisServices : IMantisServices
    {
        private readonly IMediator _mediator;

        public MantisServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result<TasksResponseDto>> GetTasksAsync(string path)
        {
            var query = new GetTaskQuery(path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<Result<TaskByIdResponseDto>> GetTaskByIdAsync(string path, int id)
        {
            var query = new GetTaskByIdQuery(path, id);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<Result<TaskCreateResponseDto>> CreateTaskAsync(TaskCreateRequestDto request, string path)
        {
            var query = new CreateTaskCommand(request,path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<Result<TaskResponseDto>> UpdateTaskAsync(TaskCreateRequestDto request)
        {
            var query = new UpdateTaskQuery(request);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<Result<List<TaskCategoryResponseDto>>> GetCategories()
        {
            var query = new GetCategoryQuery();
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<Result<TaskProjectResponseDto>> GetProjectByNameAsync(TaskProjectRequestDto request)
        {
            var query = new GetProjectByNameQuery(request.Name, request.Path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<Result<TaskTrackingResponseDto>> PatchTaskAsync(TaskPatchRequestDto request, string path)
        {
        
            var query = new PatchTaskCommand(request,path);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }

        public async Task<Result<IssueTrackingResponseDto>> GetIssueTrackingByChangeSetId(int changeSetId)
        {
          
            var query = new GetIssueTrackingByChangeSetIdCommand(changeSetId);
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return result;
            }
        }
    }
}
