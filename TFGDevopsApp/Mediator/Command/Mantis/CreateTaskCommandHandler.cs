using MediatR;
using TFGDevopsApp.Common.Exceptions;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Mediator.Command.Mantis;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<TaskCreateResponseDto>>
    {
        private readonly IConfiguration _configuration;
        
        public CreateTaskCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        async Task<Result<TaskCreateResponseDto>> IRequestHandler<CreateTaskCommand, Result<TaskCreateResponseDto>>.Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {

                TaskCreateResponseDto result = null;
                var mantisBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:Url");
                var authToken = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:MantisRest:AuthToken");

                if (!string.IsNullOrEmpty(mantisBaseUrl))
                {
                    var url = $"{mantisBaseUrl}{request.Path}";
                    result = await RestClientHelper.AuthorizedPostAsync<TaskCreateResponseDto, Issue>(url, request.Issue, authToken);
                }

                var response = new TaskCreateResponseDto()
                {
                    Issue = request.Issue
                };

                if (result != null)
                {
                    return await Task.FromResult(
                        new Result<TaskCreateResponseDto>()
                        {
                            Data = response,
                            Message = $"Task {request.Issue?.Summary} creado correctamente",
                            Success = true
                        });

                }
                else
                {
                    return await Task.FromResult(
                        new Result<TaskCreateResponseDto>()
                        {
                            Data = result,
                            Message = "No se pudo crear el issue",
                            Success = false
                        });
                }
            }
            catch (RestClientException ex)
            {
                return new Result<TaskCreateResponseDto>()
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
                };
            }
            catch (Exception ex)
            {
                return new Result<TaskCreateResponseDto>()
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}