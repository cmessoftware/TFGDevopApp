using MediatR;
using TFGDevopsApp.Common;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp.Mediator.Queries.Plastic.WorkSpaces
{
    public class GetWorkSpacesQueryHandler : IRequestHandler<GetWorkSpacesQuery, Result<List<WorkspaceResponseDto>>>
    {
        private readonly IConfiguration _configuration;

        public GetWorkSpacesQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<List<WorkspaceResponseDto>>> Handle(GetWorkSpacesQuery request, CancellationToken cancellationToken)
        {
            List<WorkspaceResponseDto> response = null;
            var plasticBaseUrl = _configuration.GetValue<string>(Constants.PlasticBaseUrlKey);

            if (!string.IsNullOrEmpty(plasticBaseUrl))
                response = RestClientHelper.Get<List<WorkspaceResponseDto>>(plasticBaseUrl + request.Path);


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<List<WorkspaceResponseDto>>()
                    {
                        Data = response,
                        Message = "WorkSpaces encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<List<WorkspaceResponseDto>>()
                    {
                        Data = null,
                        Message = "No se encontraron workspaces",
                        Success = false
                    });
            }
        }
    }
}
