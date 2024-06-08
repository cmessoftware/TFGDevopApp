using MediatR;
using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;

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