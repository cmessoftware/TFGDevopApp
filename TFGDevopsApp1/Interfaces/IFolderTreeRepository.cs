using TFGDevopsApp.Dtos.FolderTree;

namespace TFGDevopsApp.Interfaces
{
    public interface IFolderTreeRepository
    {
        Task<FolderTree> GetFolderFiles(string folderPath);
    }
}