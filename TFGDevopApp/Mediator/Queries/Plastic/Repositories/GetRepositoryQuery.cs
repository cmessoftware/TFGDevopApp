using MediatR;
using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;


namespace TFGDevopsApp.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoryQuery : IRequest<ResultMessage<RepositoryResponseDto>>
    {
        public string Path { get; }

        public GetRepositoryQuery(string path)
        {
            Path = path;
        }

    }
}
