using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.ChangeSets;

namespace TFGDevopsApp1.Mediator.Queries.Plastic.ChangeSets
{
    public class GetChangeSetsQuery : IRequest<Result<List<ChangeSetResponseDto>>>
    {
        public string Path;

        public GetChangeSetsQuery(string path)
        {
            Path = path;
        }
    }
}