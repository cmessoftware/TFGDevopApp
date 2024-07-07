using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Repositories;


namespace TFGDevopsApp1.Mediator.Queries.Plastic.Repositories
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
