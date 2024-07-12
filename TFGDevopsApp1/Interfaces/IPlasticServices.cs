using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dto.Plastic.Workspaces;
using TFGDevopsApp.Dtos.FolderTree;
using TFGDevopsApp.Dtos.Plastic.ChangeSets;
using TFGDevopsApp.Dtos.Plastic.Repositories;
using TFGDevopsApp.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp.Interfaces
{
    public interface IPlasticServices
    {
        Task<Result<bool>> RemoveWorkSpacesAsync(string name);
        Task<Result<CreateRepositoryResponseDto>> CreateRepositoryAsync(RepositoryCreateRequestDto repository);
       
        Task<Result<bool>> EditWorkspaceAsync(EditWorkspaceRequestDto workspace);
        Task<Result<bool>> CreateWorkSpaceAsync(WorkspaceRequestDto workspace);
        Task<string> GetFileContentAsyc(string path);
        Task<Result<FolderTree>> GetFolderTreeAsync(string path);
        Task<Result<RepositoryResponseDto>> GetRepositoryAsync(string path);
        Task<Result<List<RepositoryResponseDto>>> GetRepositoriesAsync(string path);
        Task<Result<List<WorkspaceResponseDto>>> GetWorkSpacesAsync(string path);
        Task<Result<WorkspaceResponseDto>> GetWorkSpaceByNameAsync(string path, string name);
        Task<Result<List<ChangeSetResponseDto>>> GetChangeSetsAsync(string path);

    }
}