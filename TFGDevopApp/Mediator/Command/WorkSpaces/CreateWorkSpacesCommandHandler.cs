using MediatR;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Plastic;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Command.WorkSpaces
{
    public class CreateWorkSpacesCommandHandler : IRequestHandler<CreateWorkSpacesCommand, ResultMessage<bool>>
    {
        private readonly IConfiguration _configuration;

        public CreateWorkSpacesCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResultMessage<bool>> Handle(CreateWorkSpacesCommand request, CancellationToken cancellationToken)
        {
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevopsApp.Web:environmentVariables:PLASTIC_API_URL");
            if (string.IsNullOrEmpty(plasticBaseUrl))
                return await Task.FromResult(
                    new ResultMessage<bool>()
                    {
                        Data = false,
                        Message = "Failed to create workspace.",
                        Success = false
                    });

            var response = RestClientHelper.Post<bool, WorkspaceRequestDto>($"{plasticBaseUrl}/wkspaces", request.Workspace);

            if (response)
            {
                return await Task.FromResult(
                    new ResultMessage<bool>()
                    {
                        Data = true,
                        Message = $"Workspace {request.Workspace.Name} created successfully.",
                        Success = true
                    });
            }
            else
            {
                return await Task.FromResult(
                    new ResultMessage<bool>()
                    {
                        Data = false,
                        Message = "Failed to create workspace.",
                        Success = false
                    });
            }
        }
    }
}

    