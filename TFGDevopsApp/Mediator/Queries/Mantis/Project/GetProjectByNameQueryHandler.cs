using MediatR;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Interfaces;
using TFGDevopsApp.Core.Helpers;
using Microsoft.CodeAnalysis;
using TFGDevopsApp.Dtos.Mantis.Project;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Project
{
    public class GetProjectByNameQueryHandler : IRequestHandler<GetProjectByNameQuery, Result<TaskProjectResponseDto>>
    {
        private readonly IConfiguration _configuration;

        public GetProjectByNameQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<TaskProjectResponseDto>> Handle(GetProjectByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<TaskProjectResponseDto> response = null;
                var mantisBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:Url");
                var authToken = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:AuthToken");

                if (!string.IsNullOrEmpty(mantisBaseUrl))
                {
                    var url = $"{mantisBaseUrl}{request.Path}";
                    response = await RestClientHelper.AuthorizedGetAsync<List<TaskProjectResponseDto>>(url, authToken);
                }


                if (response != null)
                {
                    var project = new TaskProjectResponseDto()
                    {
                        Project = response.FirstOrDefault(x => x.Project.Name == request.Name)?.Project
                    };
                   
                    return await Task.FromResult(
                        new Result<TaskProjectResponseDto>()
                        {
                            Data = project,
                            Message = $"Proyecto {request.Name} encontrado",
                            Success = true
                        });

                }
                else
                {
                    return await Task.FromResult(
                        new Result<TaskProjectResponseDto>()
                        {
                            Data = null,
                            Message = "No se encontraron issues",
                            Success = false
                        });
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(
                                       new Result<TaskProjectResponseDto>()
                                       {
                        Data = null,
                        Message = ex.Message,
                        Success = false
                    });
            }
        }
    }
}
