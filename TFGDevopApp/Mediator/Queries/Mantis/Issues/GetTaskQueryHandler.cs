using MediatR;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, Result<TaskResponseDto>>
    {
        private readonly IConfiguration _configuration;


        public GetTaskQueryHandler(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<Result<TaskResponseDto>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            TaskResponseDto response = null;
            var mantisBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:Url");
            var authToken = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:AuthToken");

            if (!string.IsNullOrEmpty(mantisBaseUrl))
            {
                var url = $"{mantisBaseUrl}{request.Path}";
                response = await RestClientHelper.SecurityGetAsync<TaskResponseDto>(url, authToken);

            }
    
            if (response != null)
            {
                return await Task.FromResult(
                    new Result<TaskResponseDto>()
                    {
                        Data = response,
                        Message = "Tareas encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<TaskResponseDto>()
                    {
                        Data = null,
                        Message = "No se encontraron tareas",
                        Success = false
                    });
            }
        }
    }
}
