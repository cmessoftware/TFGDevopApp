using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Result<Issue>>
    {
        private readonly IConfiguration _configuration;

        public GetTaskByIdQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<Issue>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            Issue response = null;
            var mantisBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:Url");
            var authToken = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:AuthToken");

            if (!string.IsNullOrEmpty(mantisBaseUrl))
            {
                var url = $"{mantisBaseUrl}{request.Path}/{request.Id}";
               // response = await RestClientHelper.SecurityGetAsync<TaskCreateResponseDto>(url, authToken);
            }


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<Issue>()
                    {
                        Data = response,
                        Message = "Categorias encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<Issue>()
                    {
                        Data = null,
                        Message = "No se encontraron issues",
                        Success = false
                    });
            }
        }
    }
}
