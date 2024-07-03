using MediatR;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Repositories;

namespace TFGDevopsApp.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoryQueryHandler : IRequestHandler<GetRepositoryQuery, Result<RepositoryResponseDto>>
    {
        private readonly IConfiguration _configuration;

        public GetRepositoryQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<RepositoryResponseDto>> Handle(GetRepositoryQuery request, CancellationToken cancellationToken)
        {
            RepositoryResponseDto response = null;
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevopsTools.Server:environmentVariables:PlasticRest:Url");

            if (!string.IsNullOrEmpty(plasticBaseUrl))
            {
                var url = plasticBaseUrl + request.Path;
                response = RestClientHelper.Get<RepositoryResponseDto>(url);
            }


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<RepositoryResponseDto>()
                    {
                        Data = response,
                        Message = "Repositorios encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<RepositoryResponseDto>()
                    {
                        Data = null,
                        Message = "No se encontró el repositoriosolicitado",
                        Success = false
                    });
            }
        }
    }
}
