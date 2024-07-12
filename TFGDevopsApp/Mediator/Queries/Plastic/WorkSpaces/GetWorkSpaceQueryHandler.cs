using MediatR;
using TFGDevopsApp.Common;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp.Mediator.Queries.Plastic.WorkSpaces
{
    public class GetWorkSpaceQueryHandler : IRequestHandler<GetWorkSpaceQuery, Result<WorkspaceResponseDto>>
    {
        private readonly IConfiguration _configuration;

        public GetWorkSpaceQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<WorkspaceResponseDto>> Handle(GetWorkSpaceQuery request, CancellationToken cancellationToken)
        {
            WorkspaceResponseDto response = null;
            var plasticBaseUrl = _configuration.GetValue<string>(Constants.PlasticBaseUrlKey);

            if (!string.IsNullOrEmpty(plasticBaseUrl))
            {
                string url = $"{plasticBaseUrl}{request.Path}/{request.Name}";
                response = RestClientHelper.Get<WorkspaceResponseDto>(url);
            }


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<WorkspaceResponseDto>()
                    {
                        Data = response,
                        Message = "WorkSpaces encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<WorkspaceResponseDto>()
                    {
                        Data = null,
                        Message = "No se encontraron workspaces",
                        Success = false
                    });
            }
        }
    }
}
