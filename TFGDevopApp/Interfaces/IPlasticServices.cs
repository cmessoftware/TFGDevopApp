using System.Collections.Generic;
using System.Threading.Tasks;
using TFGDevopsApp.Components.Pages.Folder;
using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Interfaces
{
    public interface IPlasticServices
    {

        Task<string> GetFileContentAsyc(string path);
        Task<ResultMessage<FolderTree>> GetFolderTreeAsync(string path);
        Task<ResultMessage<RepositoryResponseDto>> GetRepositoryAsync(string path);
        Task<ResultMessage<List<RepositoryResponseDto>>> GetRepositoriesAsync(string path);
        Task<ResultMessage<List<WorkspaceResponseDto>>> GetWorkSpacesAsync(string path);
        Task<ResultMessage<List<ChangeSetResponseDto>>> GetChangeSetsAsync(string path);

    }
}