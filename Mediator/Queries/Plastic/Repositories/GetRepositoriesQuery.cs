using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Repositories;


namespace TFGDevopsApp1.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoriesQuery : IRequest<Result<List<RepositoryResponseDto>>>
    {
        public string Path;

        public GetRepositoriesQuery(string path)
        {
            Path = path;
        }

    }
}
