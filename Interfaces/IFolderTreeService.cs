using TFGDevopsApp1.Dtos.FolderTree;

namespace TFGDevopsApp1.Interfaces
{
    public interface IFolderTreeService
    {
        Task<FolderTree> GetRepositoryFiles(string path);
    }
}