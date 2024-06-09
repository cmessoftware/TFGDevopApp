using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Common.Helpers;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TFGDevopsApp.Dtos.Plastic.Repositories;
using TFGDevopsApp.Dtos.FolderTree;

namespace TFGDevopsApp.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoryFilesQueryHandler : IRequestHandler<GetRepositoryFilesQuery, ResultMessage<FolderTree>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetRepositoriesQueryHandler> _logger;

        public GetRepositoryFilesQueryHandler(IMapper mapper,
                                              ILogger<GetRepositoriesQueryHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultMessage<FolderTree>> Handle(GetRepositoryFilesQuery request, CancellationToken cancellationToken)
        {

            //path = string.IsNullOrEmpty(path) ? "" :
            //               (path.Split(Separator)[0] != "/" ? $"{Separator}{path}" :
            //                path);

            //path = path ==  $"{Separator}{request.RepoName}" ? "" : path;
            //path = string.IsNullOrEmpty(path.Split("/")[0]) ? path.Replace("//", "/") : $"{path}";

            _logger.LogError($"Url: {request.PathUrl} ");
            var directories = await RestClientHelper.GetAsync<DirectoryItemDto>(request.PathUrl);

            // Get all Trees from file system.
            var allTrees = _mapper.Map<FolderTree>(directories);
            // Start recursive function with the top of the tree
            LoadSubTrees(allTrees.Children, null);

            if (allTrees != null)
            {
                return await Task.FromResult(
                    new ResultMessage<FolderTree>()
                    {
                        Data = allTrees,
                        Message = "Archivos encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new ResultMessage<FolderTree>()
                    {
                        Data = null,
                        Message = "No se encontraron archivos",
                        Success = false
                    });
            }
        }

        private static void LoadSubTrees(List<FolderTree> nodes, int? revisionId)
        {
            // Get all nodes that are children of the current parentId
            var children = nodes.Where(x => x.RevisionId == revisionId).ToList();

            foreach (var child in children)
            {
                // Recursively load subtrees for each child
                LoadSubTrees(nodes, child.RevisionId);

                // Find the parent node and add this child to its Children list
                var parent = nodes.Find(x => x.Id == revisionId);
                if (parent != null)
                {
                    parent.Children.Add(child);
                }
            }
        }


    }
}
