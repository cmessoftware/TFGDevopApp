using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.ChangeSets;

namespace TFGDevopsApp.Mediator.Queries.Plastic.ChangeSets
{
    public class GetChangeSetsQuery : IRequest<ResultMessage<List<ChangeSetResponseDto>>>
    {
        public string Path;

        public GetChangeSetsQuery(string path)
        {
            Path = path;
        }
    }
}