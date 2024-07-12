using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Category;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetCategoryQuery : IRequest<Result<List<TaskCategoryResponseDto>>>
    {
        public GetCategoryQuery()
        {
        }
    }
}