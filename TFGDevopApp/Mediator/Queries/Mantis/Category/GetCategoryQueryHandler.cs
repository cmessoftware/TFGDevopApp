using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Result<List<Category>>>
    {
        private readonly IConfiguration _configuration;

        public GetCategoryQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<List<Category>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> response = null;
           


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<List<Category>>()
                    {
                        Data = response,
                        Message = "Categorias encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<List<Category>>()
                    {
                        Data = null,
                        Message = "No se encontraron categorias",
                        Success = false
                    });
            }
        }
    }
}
