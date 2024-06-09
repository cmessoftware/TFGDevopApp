using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.FolderTree;

namespace TFGDevopsApp.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoryFilesQuery : IRequest<ResultMessage<FolderTree>>
    {
        public string RepoName { get; }
        public string PathUrl { get; set; }
        public string BasePath { get; set; }
        public GetRepositoryFilesQuery(string basePath,
                                       string pathUrl,
                                       string repoName)
        {
            RepoName = repoName;
            BasePath = basePath;
            PathUrl = pathUrl;
        }

        public GetRepositoryFilesQuery(string pathUrl)
        {
            PathUrl = pathUrl;
        }
    }
}
