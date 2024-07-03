namespace TFGDevopsApp.Interfaces
{
    public interface IFolderTreeRepository
    {
        Task<FolderTree> GetFolderFiles(string folderPath);
    }
}