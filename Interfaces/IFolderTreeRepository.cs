using TFGDevopsApp1.Dtos.FolderTree;

namespace TFGDevopsApp1.Interfaces
{
    public interface IFolderTreeRepository
    {
        Task<FolderTree> GetFolderFiles(string folderPath);
    }
}