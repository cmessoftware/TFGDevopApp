using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Category;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Mediator.Command.Mantis;
using TFGDevopsApp.Mediator.Queries.Mantis.Issues;

namespace TFGDevopsApp.Services
{
    public class MantisServices : IMantisServices
    {
        private readonly IMediator _mediator;

        public MantisServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result<TasksResponseDto>> GetTasks(string path)
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

        public async Task<Result<Issue>> GetTaskById(string path, int id)
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

        public async Task<Result<Issue>> CreateTask(Issue request)
        {
            var query = new CreateTaskCommand(request);
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

        public async Task<Result<TaskCreateResponseDto>> UpdateTask(TaskCreateRequestDto request)
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

        public Task<Result<List<TaskCreateResponseDto>>> GetTaskById(int id)
        {
            throw new NotImplementedException();
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
    }
}
