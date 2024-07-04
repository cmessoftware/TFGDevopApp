using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Interfaces
{
    public interface IMantisServices
    {
        Task<Result<Issue>> GetTaskById(string path, int id);
        Task<Result<Issue>> CreateTask(Issue request);
        Task<Result<TaskResponseDto>> GetTasks(string path);
        Task<Result<List<Category>>> GetCategories();
        Task<Result<TaskCreateResponseDto>> UpdateTask(TaskCreateRequestDto request);
    }
}