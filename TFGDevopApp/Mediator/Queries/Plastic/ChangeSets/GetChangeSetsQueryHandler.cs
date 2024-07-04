using MediatR;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.ChangeSets;

namespace TFGDevopsApp.Mediator.Queries.Plastic.ChangeSets
{
    public class GetChangeSetsQueryHandler : IRequestHandler<GetChangeSetsQuery, Result<List<ChangeSetResponseDto>>>
    {
        private readonly IConfiguration _configuration;

        public GetChangeSetsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<List<ChangeSetResponseDto>>> Handle(GetChangeSetsQuery request, CancellationToken cancellationToken)
        {
            List<ChangeSetResponseDto> response = null;
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:PLASTIC_API_URL");

            if (!string.IsNullOrEmpty(plasticBaseUrl))
                response = RestClientHelper.Get<List<ChangeSetResponseDto>>(plasticBaseUrl + request.Path);


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<List<ChangeSetResponseDto>>()
                    {
                        Data = response,
                        Message = "Change sets encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<List<ChangeSetResponseDto>>()
                    {
                        Data = null,
                        Message = "No se encontraron change sets",
                        Success = false
                    });
            }
        }
    }
}
