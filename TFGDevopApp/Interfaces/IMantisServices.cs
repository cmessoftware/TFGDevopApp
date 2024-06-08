using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Models.Mantis;

namespace TFGDevopsApp.Interfaces
{
    public interface IMantisServices
    {
        Task<ResultMessage<TaskResponseDto>> GetTaskById(string path, int id);
        Task<ResultMessage<TaskResponseDto>> CreateTask(TaskRequestDto request);
        Task<ResultMessage<TaskResponseDto>> GetTasks(string path);
        Task<ResultMessage<TaskResponseDto>> UpdateTask(TaskRequestDto request);
    }
}