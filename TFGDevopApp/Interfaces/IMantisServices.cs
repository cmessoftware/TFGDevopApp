using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Interfaces
{
    public interface IMantisServices
    {
        Task<Result<TaskResponseDto>> GetTaskById(string path, int id);
        Task<Result<TaskResponseDto>> CreateTask(TaskRequestDto request);
        Task<Result<TaskResponseDto>> GetTasks(string path);
        Task<Result<TaskResponseDto>> UpdateTask(TaskRequestDto request);
    }
}