using MediatR;
using TFGDevopsApp.Common.Enum;
using TFGDevopsApp.Common.Exceptions;
using TFGDevopsApp.Common.Extensions;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Mediator.Command.Mantis;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetIssueTrackingByChangeSetIdCommandHandler : IRequestHandler<GetIssueTrackingByChangeSetIdCommand, Result<IssueTrackingResponseDto>>
    {
        private readonly IConfiguration _configuration;
        private readonly RegisterIssuesActionHelper _registerIssuesActionHelper;

        public GetIssueTrackingByChangeSetIdCommandHandler(IConfiguration configuration,
                                        RegisterIssuesActionHelper registerIssuesActionHelper)
        {
            _configuration = configuration;
            _registerIssuesActionHelper = registerIssuesActionHelper;
        }


        public async Task<Result<IssueTrackingResponseDto>> Handle(GetIssueTrackingByChangeSetIdCommand request, CancellationToken cancellationToken)
        {
            try
            {

        
                var result = await _registerIssuesActionHelper.GetIssueTrackingByChangeSetId(request.ChangeSetId);
              
      
                if (result != null)
                {
                    await _registerIssuesActionHelper.RegisterPatchTask(result.IssueId, EnumIssueType.RequestCodeReview.ToInt(), request.ChangeSetId);

                    return await Task.FromResult(
                        new Result<IssueTrackingResponseDto>()
                        {
                            Data = result,
                            Message = $"Task {request} asociado correctamente",
                            Success = true
                        });

                }
                else
                {
                    return await Task.FromResult(
                        new Result<IssueTrackingResponseDto>()
                        {
                            Data = null,
                            Message = "No se pudo crear el issue",
                            Success = false
                        });
                }
            }
            catch (RestClientException ex)
            {
                return new Result<IssueTrackingResponseDto>()
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
                };
            }
            catch (Exception ex)
            {
                return new Result<IssueTrackingResponseDto>()
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
        
    }
}