using MediatR;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Repositories;

namespace TFGDevopsApp1.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoriesQueryHandler : IRequestHandler<GetRepositoriesQuery, Result<List<RepositoryResponseDto>>>
    {
        private readonly IConfiguration _configuration;

        public GetRepositoriesQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<List<RepositoryResponseDto>>> Handle(GetRepositoriesQuery request, CancellationToken cancellationToken)
        {
            List<RepositoryResponseDto> response = null;
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:PlasticRest:Url");

            if (!string.IsNullOrEmpty(plasticBaseUrl))
                response = RestClientHelper.Get<List<RepositoryResponseDto>>(plasticBaseUrl + request.Path);


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<List<RepositoryResponseDto>>()
                    {
                        Data = response,
                        Message = "Repositorios encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<List<RepositoryResponseDto>>()
                    {
                        Data = null,
                        Message = "No se encontraron repositorios",
                        Success = false
                    });
            }
        }
    }
}
