using AutoMapper;
using MediatR;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.FolderTree;
using TFGDevopsApp.Dtos.Plastic.Repositories;

namespace TFGDevopsApp.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoryFilesQueryHandler : IRequestHandler<GetRepositoryFilesQuery, Result<FolderTree>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetRepositoriesQueryHandler> _logger;

        private static List<string> excludesFiles = new List<string>
        {
            ".git",
            ".plastic",
            ".vs",
            "packages",
            "bin",
            "obj",
            "node_modules",
            "dist",
            "build",
            "out",
            "coverage",
            "logs",
            "temp"
        };


        public GetRepositoryFilesQueryHandler(IMapper mapper,
                                              ILogger<GetRepositoriesQueryHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<FolderTree>> Handle(GetRepositoryFilesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogError($"Url: {request.PathUrl} ");
            var directories = await RestClientHelper.GetAsync<DirectoryItemDto>(request.PathUrl);

            // Get all Trees from file system.
            var allTrees = _mapper.Map<FolderTree>(directories);
            // Start recursive function with the top of the tree
            LoadSubTrees(allTrees.Children, directories.RevisionId);

            if (allTrees != null)
            {
                return await Task.FromResult(
                    new Result<FolderTree>()
                    {
                        Data = allTrees,
                        Message = "Archivos encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<FolderTree>()
                    {
                        Data = null,
                        Message = "No se encontraron archivos",
                        Success = false
                    });
            }
        }

        private static void LoadSubTrees(List<FolderTree> children, int? revisionId)
        {
            // Get all nodes that are children of the current parentId
            children = children.Where(x => x.RevisionId == revisionId).ToList();

            foreach (var child in children)
            {
                if (IsExcludeFile(child.Path))
                    continue;
                // Recursively load subtrees for each child
                LoadSubTrees(children, child.RevisionId);

                // Find the parent node and add this child to its Children list
                var parent = children.Find(x => x.Id == revisionId);
                if (parent != null)
                {
                    parent.Children.Add(child);
                }
            }
        }

        private static bool IsExcludeFile(string path)
        {
            return excludesFiles.Any(x => path.Contains(x));
            
        }
    }
}
