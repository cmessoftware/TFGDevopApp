using MediatR;
using TFGDevopsApp1.Core.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Category;
using TFGDevopsApp1.Dtos.Mantis.Issues;
using TFGDevopsApp1.Dtos.Mantis.Project;
using TFGDevopsApp1.Interfaces;
using TFGDevopsApp1.Mediator.Command.Mantis;
using TFGDevopsApp1.Mediator.Queries.Mantis.Issues;
using TFGDevopsApp1.Mediator.Queries.Mantis.Project;
using IssueDto = TFGDevopsApp1.Dtos.Mantis.Issues;


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

        public async Task<Result<TaskResponseDto>> GetTaskById(string path, int id)
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

    }
}
