using TFGDevopsApp1.Core.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Category;
using TFGDevopsApp1.Dtos.Mantis.Issues;
using TFGDevopsApp1.Dtos.Mantis.Project;

namespace TFGDevopsApp1.Interfaces
{
    public interface IMantisServices
    {
        Task<Result<TaskResponseDto>> GetTaskById(string path, int id);
        Task<Result<TaskCreateResponseDto>> CreateTaskAsync(TaskCreateRequestDto request, string path);
        Task<Result<TasksResponseDto>> GetTasksAsync(string path);
        Task<Result<List<TaskCategoryResponseDto>>> GetCategories();
        Task<Result<TaskResponseDto>> UpdateTaskAsync(TaskCreateRequestDto request);
        Task<Result<TaskProjectResponseDto>> GetProjectByNameAsync(TaskProjectRequestDto request);
    }
}