using System.Collections.Generic;
using System.Threading.Tasks;
using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.FolderTree;
using TFGDevopsApp.Dtos.Plastic.ChangeSets;
using TFGDevopsApp.Dtos.Plastic.Repositories;
using TFGDevopsApp.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp.Interfaces
{
    public interface IPlasticServices
    {
        Task<ResultMessage<bool>> CreateRepositoryAsync(CreateRepositoryResponseDto repository);
        Task<ResultMessage<bool>> CreateWorkSpaceAsync(WorkspaceRequestDto workspace);
        Task<string> GetFileContentAsyc(string path);
        Task<ResultMessage<FolderTree>> GetFolderTreeAsync(string path);
        Task<ResultMessage<RepositoryResponseDto>> GetRepositoryAsync(string path);
        Task<ResultMessage<List<RepositoryResponseDto>>> GetRepositoriesAsync(string path);
        Task<ResultMessage<List<WorkspaceResponseDto>>> GetWorkSpacesAsync(string path);
        Task<ResultMessage<List<ChangeSetResponseDto>>> GetChangeSetsAsync(string path);

    }
}