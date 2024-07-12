using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Repositories;


namespace TFGDevopsApp.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoryQuery : IRequest<Result<RepositoryResponseDto>>
    {
        public string Path { get; }

        public GetRepositoryQuery(string path)
        {
            Path = path;
        }

    }
}
