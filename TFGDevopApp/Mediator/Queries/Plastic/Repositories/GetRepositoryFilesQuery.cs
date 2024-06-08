using MediatR;
using TFGDevopsApp.Components.Pages.Folder;
using TFGDevopsApp.Core.Models.Result;

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
