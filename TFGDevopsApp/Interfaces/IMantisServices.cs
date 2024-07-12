using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Category;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Dtos.Mantis.Project;

namespace TFGDevopsApp.Interfaces
{
    public interface IMantisServices
    {
        Task<Result<TaskResponseDto>> GetTaskById(string path, int id);
        Task<Result<TaskCreateResponseDto>> CreateTaskAsync(TaskCreateRequestDto request, string path);
        Task<Result<TasksResponseDto>> GetTasksAsync(string path);
        Task<Result<List<TaskCategoryResponseDto>>> GetCategories();
        Task<Result<TaskResponseDto>> UpdateTaskAsync(TaskCreateRequestDto request);
    }
}