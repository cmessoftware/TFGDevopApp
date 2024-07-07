using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dto.Plastic.Workspaces;
using TFGDevopsApp1.Dtos.FolderTree;
using TFGDevopsApp1.Dtos.Plastic.ChangeSets;
using TFGDevopsApp1.Dtos.Plastic.Repositories;
using TFGDevopsApp1.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp1.Interfaces
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
        Task<Result<List<ChangeSetResponseDto>>> GetChangeSetsAsync(string path);

    }
}