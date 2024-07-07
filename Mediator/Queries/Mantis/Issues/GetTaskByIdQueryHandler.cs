using MediatR;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Mantis.Issues;
using TFGDevopsApp1.Interfaces;

namespace TFGDevopsApp1.Mediator.Queries.Mantis.Issues
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Result<TaskResponseDto>>
    {
        private readonly IConfiguration _configuration;

        public GetTaskByIdQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<TaskResponseDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            TaskResponseDto response = null;
            var mantisBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:Url");
            var authToken = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:AuthToken");

            if (!string.IsNullOrEmpty(mantisBaseUrl))
            {
                var url = $"{mantisBaseUrl}{request.Path}/{request.Id}";
                response = await RestClientHelper.AuthorizedGetAsync<TaskResponseDto>(url, authToken);
            }


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<TaskResponseDto>()
                    {
                        Data = response,
                        Message = "Categorias encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<TaskResponseDto>()
                    {
                        Data = null,
                        Message = "No se encontraron issues",
                        Success = false
                    });
            }
        }
    }
}
