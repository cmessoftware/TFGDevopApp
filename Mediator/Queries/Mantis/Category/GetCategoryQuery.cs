using MediatR;
using TFGDevopsApp1.Core.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Category;

namespace TFGDevopsApp1.Mediator.Queries.Mantis.Issues
{
    public class GetCategoryQuery : IRequest<Result<List<TaskCategoryResponseDto>>>
    {
        public GetCategoryQuery()
        {
        }
    }
}