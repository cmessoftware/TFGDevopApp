using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Repositories;


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
