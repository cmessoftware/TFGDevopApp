using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Category;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Result<List<TaskCategoryResponseDto>>>
    {
        private readonly IConfiguration _configuration;

        public GetCategoryQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<List<TaskCategoryResponseDto>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            List<TaskCategoryResponseDto> response = null;
           


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<List<TaskCategoryResponseDto>>()
                    {
                        Data = response,
                        Message = "Categorias encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<List<TaskCategoryResponseDto>>()
                    {
                        Data = null,
                        Message = "No se encontraron categorias",
                        Success = false
                    });
            }
        }

    }
}
