using MediatR;
using TFGDevopsApp.Core.Models.Result;
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

        public async Task<Result<TaskResponseDto>> GetTasks(string path)
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

        public async Task<Result<TaskResponseDto>> CreateTask(TaskRequestDto request)
        {
            var query = new CreateTaskQuery(request);
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

        public async Task<Result<TaskResponseDto>> UpdateTask(TaskRequestDto request)
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

        public Task<Result<List<TaskResponseDto>>> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
