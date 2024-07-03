namespace TFGDevopsApp.Interfaces
{
    public interface IFolderTreeService
    {
        Task<FolderTree> GetRepositoryFiles(string path);
    }
}