using MediatR;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Interfaces;
using TFGDevopsApp1.Core.Helpers;
using Microsoft.CodeAnalysis;
using TFGDevopsApp1.Dtos.Mantis.Project;

namespace TFGDevopsApp1.Mediator.Queries.Mantis.Project
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
