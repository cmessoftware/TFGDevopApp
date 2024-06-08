using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Interfaces;
using TFGDevopsApp.Mediator.Queries.Mantis.Issues;
using TFGDevopsApp.Models.Mantis;

namespace TFGDevopsApp.Services
{
    public class MantisServices : IMantisServices
    {
        private readonly IMediator _mediator;

        public MantisServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResultMessage<TaskResponseDto>> GetTasks(string path)
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

        public async Task<ResultMessage<TaskResponseDto>> GetTaskById(string path, int id)
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

        public async Task<ResultMessage<TaskResponseDto>> CreateTask(TaskRequestDto request)
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

        public async Task<ResultMessage<TaskResponseDto>> UpdateTask(TaskRequestDto request)
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

        public Task<ResultMessage<List<TaskResponseDto>>> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
