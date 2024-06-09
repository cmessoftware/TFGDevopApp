using AutoMapper;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Dtos.FolderTree;
using TFGDevopsApp.Dtos.Plastic.Repositories;
using TFGDevopsApp.Interfaces;

namespace TFGDevopsApp.Services
{
    public class FolderTreeService : IFolderTreeService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public FolderTreeService(IConfiguration configuration,
                                 IMapper mapper)

        {
            _configuration = configuration;
            this._mapper = mapper;
        }

        private List<FolderTree> LoadSubTrees(List<FolderTree> allTrees, FolderTree? parentTree)
        {
            var trees = allTrees.Where(x => x.Id == parentTree?.Id).ToList();

            foreach (var tree in trees)
                tree.Children = LoadSubTrees(allTrees, tree);

            return trees;
        }

        public async Task<FolderTree> GetRepositoryFiles(string path)
        {
            try
            {
                var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevopsTools.Server:environmentVariables:PlasticRest:Url");
                var url = $"{plasticBaseUrl}{path}/branches/main/contents";
                var directories = await RestClientHelper.GetAsync<DirectoryItemDto>(url);

                //var files = _plasticService.GetRepositoryFolders(folderPath);
                // Get all Trees from file system.
                //var allTrees = await _folderTreeRepository.GetFolderFiles(folderPath);
                var allTrees = _mapper.Map<FolderTree>(directories);
                // Start recursive function with the top of the tree
                //LoadSubTrees(allTrees.SubTrees, null);

                //allTrees.SubTrees = allTrees.SubTrees.Where(x => x.ParentTreeId == null).ToList();

                return allTrees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
