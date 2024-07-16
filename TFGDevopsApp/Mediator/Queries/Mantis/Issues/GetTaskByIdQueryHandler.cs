using MediatR;
using TFGDevopsApp.Common;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Interfaces;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Result<TaskByIdResponseDto>>
    {
        private readonly IConfiguration _configuration;

        public GetTaskByIdQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<TaskByIdResponseDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            TaskByIdResponseDto response = null;
            var mantisBaseUrl = _configuration.GetValue<string>(Constants.MantisBaseUrl);
            var authToken = _configuration.GetValue<string>(Constants.MantisAuthKey);

            if (!string.IsNullOrEmpty(mantisBaseUrl))
            {
                var url = $"{mantisBaseUrl}{request.Path}/{request.Id}";
                response = await RestClientHelper.AuthorizedGetAsync<TaskByIdResponseDto>(url, authToken);
            }


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<TaskByIdResponseDto>()
                    {
                        Data = response,
                        Message = "Issues encontrados",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<TaskByIdResponseDto>()
                    {
                        Data = null,
                        Message = "No se encontraron issues",
                        Success = false
                    });
            }
        }
    }
}
