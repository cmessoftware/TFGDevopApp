using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetCategoryQuery : IRequest<Result<List<Category>>>
    {
        public GetCategoryQuery()
        {
        }
    }
}