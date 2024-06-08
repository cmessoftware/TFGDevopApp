using MediatR;
using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;


namespace TFGDevopsApp.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoriesQuery : IRequest<ResultMessage<List<RepositoryResponseDto>>>
    {
        public string Path;

        public GetRepositoriesQuery(string path)
        {
            Path = path;
        }

    }
}
