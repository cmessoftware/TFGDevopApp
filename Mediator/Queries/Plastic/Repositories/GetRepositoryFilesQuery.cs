using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.FolderTree;

namespace TFGDevopsApp1.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoryFilesQuery : IRequest<Result<FolderTree>>
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
