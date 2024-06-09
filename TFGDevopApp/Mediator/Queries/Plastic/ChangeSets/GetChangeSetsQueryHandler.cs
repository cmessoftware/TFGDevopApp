using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Common.Helpers;
using MediatR;
using TFGDevopsApp.Dtos.Plastic.ChangeSets;

namespace TFGDevopsApp.Mediator.Queries.Plastic.ChangeSets
{
    public class GetChangeSetsQueryHandler : IRequestHandler<GetChangeSetsQuery, ResultMessage<List<ChangeSetResponseDto>>>
    {
        private readonly IConfiguration _configuration;

        public GetChangeSetsQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResultMessage<List<ChangeSetResponseDto>>> Handle(GetChangeSetsQuery request, CancellationToken cancellationToken)
        {
            List<ChangeSetResponseDto> response = null;
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevopsApp.Web:environmentVariables:PLASTIC_API_URL");

            if (!string.IsNullOrEmpty(plasticBaseUrl))
                response = RestClientHelper.Get<List<ChangeSetResponseDto>>(plasticBaseUrl + request.Path);


            if (response != null)
            {
                return await Task.FromResult(
                    new ResultMessage<List<ChangeSetResponseDto>>()
                    {
                        Data = response,
                        Message = "Change sets encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new ResultMessage<List<ChangeSetResponseDto>>()
                    {
                        Data = null,
                        Message = "No se encontraron change sets",
                        Success = false
                    });
            }
        }
    }
}
