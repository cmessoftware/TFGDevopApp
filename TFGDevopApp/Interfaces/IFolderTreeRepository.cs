using TFGDevopsApp.Components.Pages.Folder;

namespace TFGDevopsApp.Interfaces
{
    public interface IFolderTreeRepository
    {
        Task<FolderTree> GetFolderFiles(string folderPath);
    }
}