using System.Threading.Tasks;
using TFGDevopsApp.Components.Pages.Folder;

namespace TFGDevopsApp.Interfaces
{
    public interface IFolderTreeService
    {
        Task<FolderTree> GetRepositoryFiles(string path);
    }
}