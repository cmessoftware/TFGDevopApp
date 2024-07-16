using AutoMapper;
using MediatR;
using TFGDevopsApp.Common;
using TFGDevopsApp.Common.Enum;
using TFGDevopsApp.Common.Exceptions;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Mediator.Command.Mantis;
using TFGDevopsApp.Common.Extensions;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<TaskCreateResponseDto>>
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly RegisterIssuesActionHelper _registerIssuesActionHelper;

        public CreateTaskCommandHandler(IConfiguration configuration,
                                        IMapper mapper,
                                        RegisterIssuesActionHelper registerIssuesActionHelper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _registerIssuesActionHelper = registerIssuesActionHelper;
        }


        async Task<Result<TaskCreateResponseDto>> IRequestHandler<CreateTaskCommand, Result<TaskCreateResponseDto>>.Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {

                TaskCreateResponseDto result = null;
                var mantisBaseUrl = _configuration.GetValue<string>(Constants.MantisBaseUrl);
                var authToken = _configuration.GetValue<string>(Constants.MantisAuthKey);

                if (!string.IsNullOrEmpty(mantisBaseUrl))
                {
                    var url = $"{mantisBaseUrl}{request.Path}";
                    result = await RestClientHelper.AuthorizedPostAsync<TaskCreateResponseDto, Issue>(url, request.Issue, authToken);
                }

                if (result != null)
                {
                    await RegisterReviewRequest(request, result);

                    return await Task.FromResult(
                        new Result<TaskCreateResponseDto>()
                        {
                            Data = result,
                            Message = $"Tarea Id: {result.Issue.Id} {result.Issue?.Summary} creado correctamente",
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

        private async Task<bool> RegisterReviewRequest(CreateTaskCommand request, TaskCreateResponseDto result)
        {
            var response = await _registerIssuesActionHelper.RegisterCreateTask(result.Issue, request.TaskCreateRequest.Type.ToInt(), request?.TaskCreateRequest?.ChangeSetId);

            return response;
        }
    }
}