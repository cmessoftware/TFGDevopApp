using MediatR;
using TFGDevopsApp1.Common;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp1.Mediator.Queries.Plastic.WorkSpaces
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
