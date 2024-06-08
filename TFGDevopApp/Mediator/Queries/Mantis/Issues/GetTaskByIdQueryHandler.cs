using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Models.Mantis;
using MediatR;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, ResultMessage<TaskResponseDto>>
    {
        private readonly IConfiguration _configuration;

        public GetTaskByIdQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResultMessage<TaskResponseDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            TaskResponseDto response = null;
            var mantisBaseUrl = _configuration.GetValue<string>("profiles:TFGDevopsTools.Server:environmentVariables:MantisRest:Url");
            var authToken = _configuration.GetValue<string>("profiles:TFGDevopsTools.Server:environmentVariables:MantisRest:AuthToken");

            if (!string.IsNullOrEmpty(mantisBaseUrl))
            {
                var url = $"{mantisBaseUrl}{request.Path}/{request.Id}";
                response = await RestClientHelper.SecurityGetAsync<TaskResponseDto>(url, authToken);
            }


            if (response != null)
            {
                return await Task.FromResult(
                    new ResultMessage<TaskResponseDto>()
                    {
                        Data = response,
                        Message = "Tareas encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new ResultMessage<TaskResponseDto>()
                    {
                        Data = null,
                        Message = "No se encontraron issues",
                        Success = false
                    });
            }
        }
    }
}
