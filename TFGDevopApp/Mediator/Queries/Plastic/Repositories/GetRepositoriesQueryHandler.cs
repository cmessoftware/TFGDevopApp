using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Common.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using TFGDevopsApp.Dtos.Plastic.Repositories;

namespace TFGDevopsApp.Mediator.Queries.Plastic.Repositories
{
    public class GetRepositoriesQueryHandler : IRequestHandler<GetRepositoriesQuery, ResultMessage<List<RepositoryResponseDto>>>
    {
        private readonly IConfiguration _configuration;

        public GetRepositoriesQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResultMessage<List<RepositoryResponseDto>>> Handle(GetRepositoriesQuery request, CancellationToken cancellationToken)
        {
            List<RepositoryResponseDto> response = null;
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevopsTools.Server:environmentVariables:PlasticRest:Url");

            if (!string.IsNullOrEmpty(plasticBaseUrl))
                response = RestClientHelper.Get<List<RepositoryResponseDto>>(plasticBaseUrl + request.Path);


            if (response != null)
            {
                return await Task.FromResult(
                    new ResultMessage<List<RepositoryResponseDto>>()
                    {
                        Data = response,
                        Message = "Repositorios encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new ResultMessage<List<RepositoryResponseDto>>()
                    {
                        Data = null,
                        Message = "No se encontraron repositorios",
                        Success = false
                    });
            }
        }
    }
}
