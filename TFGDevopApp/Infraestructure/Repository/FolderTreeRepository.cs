using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TFGDevopsApp.Dtos.FolderTree;
using TFGDevopsApp.Interfaces;

namespace TFGDevopsApp.Infraestructure.Repository
{
    public class FolderTreeRepository : IFolderTreeRepository
    {
        private readonly IConfiguration _configuration;

        public FolderTreeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private List<FolderTree> ReadFiles(string folderPath)
        {
            try
            {

                List<FolderTree> trees = new List<FolderTree>();
                // Read files in the current directory
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    FolderTree tree = new()
                    {
                        Name = Path.GetFileNameWithoutExtension(file)
                    };

                    trees.Add(tree);
                }

                // Recursively traverse subdirectories
                string[] subDirectories = Directory.GetDirectories(folderPath);
                foreach (string subDirectory in subDirectories)
                {
                    ReadFiles(subDirectory);
                }

                return trees;
            }
            catch (Exception ex)
            {
                throw  new IOException(ex.Message);
            }
        }

        static FolderTree CreateFolderTree(string path)
        {
            FolderTree folder = new FolderTree();

            try
            {
                foreach (string subdirectory in Directory.GetDirectories(path))
                {
                    folder.Children.Add(CreateFolderTree(subdirectory));
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Unauthorized access, continue without adding subdirectories
            }

            return folder;
        }


        public async Task<FolderTree> GetFolderFiles(string folderPath)
        {
            var folder = CreateFolderTree(folderPath);

            return folder;
        }

    }
}
