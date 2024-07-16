using MediatR;
using TFGDevopsApp.Common;
using TFGDevopsApp.Common.Enum;
using TFGDevopsApp.Common.Exceptions;
using TFGDevopsApp.Common.Extensions;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Mediator.Command.Mantis;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class PatchTaskCommandHandler : IRequestHandler<PatchTaskCommand, Result<TaskResponseDto>>
    {
        private readonly IConfiguration _configuration;
        private readonly RegisterIssuesActionHelper _registerIssuesActionHelper;

        public PatchTaskCommandHandler(IConfiguration configuration,
                                        RegisterIssuesActionHelper registerIssuesActionHelper)
        {
            _configuration = configuration;
            _registerIssuesActionHelper = registerIssuesActionHelper;
        }


        async Task<Result<TaskResponseDto>> IRequestHandler<PatchTaskCommand, Result<TaskResponseDto>>.Handle(PatchTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {

                TaskResponseDto result = null;
                var mantisBaseUrl = _configuration.GetValue<string>(Constants.MantisBaseUrl);
                var authToken = _configuration.GetValue<string>(Constants.MantisAuthKey);

                if (!string.IsNullOrEmpty(mantisBaseUrl))
                {
                    var url = $"{mantisBaseUrl}{request.Path}";
                    result = await RestClientHelper.AuthorizedPatchAsync<TaskResponseDto, TaskPatchRequestDto>(url, request.TaskPatchRequest, authToken);
                }

                await _registerIssuesActionHelper.RegisterCreateTask(result.Issue, EnumIssueType.RequestCodeReview.ToInt(), request.TaskPatchRequest.ChangeSetId);


                if (result != null)
                {
                    return await Task.FromResult(
                        new Result<TaskResponseDto>()
                        {
                            Data = null,
                            Message = $"Task {request} asociado correctamente",
                            Success = true
                        });

                }
                else
                {
                    return await Task.FromResult(
                        new Result<TaskResponseDto>()
                        {
                            Data = null,
                            Message = "No se pudo crear el issue",
                            Success = false
                        });
                }
            }
            catch (RestClientException ex)
            {
                return new Result<TaskResponseDto>()
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
                };
            }
            catch (Exception ex)
            {
                return new Result<TaskResponseDto>()
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
        
    }
}