using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Category;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Interfaces
{
    public interface IMantisServices
    {
        Task<Result<IssueTrackingResponseDto>> GetIssueTrackingByChangeSetId(int changeSetId);
        Task<Result<TaskByIdResponseDto>> GetTaskByIdAsync(string path, int id);
        Task<Result<TaskCreateResponseDto>> CreateTaskAsync(TaskCreateRequestDto request, string path);
        Task<Result<TasksResponseDto>> GetTasksAsync(string path);
        Task<Result<List<TaskCategoryResponseDto>>> GetCategories();
        Task<Result<TaskResponseDto>> UpdateTaskAsync(TaskCreateRequestDto request);

        Task<Result<TaskTrackingResponseDto>> PatchTaskAsync(TaskPatchRequestDto request, string path);
    }
}