using MediatR;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dto.Plastic.Workspaces;

namespace TFGDevopsApp.Mediator.Command.WorkSpaces
{
    public class CreateWorkSpacesCommandHandler : IRequestHandler<CreateWorkSpacesCommand, Result<bool>>
    {
        private readonly IConfiguration _configuration;

        public CreateWorkSpacesCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<bool>> Handle(CreateWorkSpacesCommand request, CancellationToken cancellationToken)
        {
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevopsApp.Web:environmentVariables:PLASTIC_API_URL");
            if (string.IsNullOrEmpty(plasticBaseUrl))
                return await Task.FromResult(
                    new Result<bool>()
                    {
                        Data = false,
                        Message = $"No se puede crear workspace {request.Workspace.Name}",
                        Success = false
                    });

            var response = RestClientHelper.Post<bool, WorkspaceRequestDto>($"{plasticBaseUrl}/wkspaces", request.Workspace);

            if (response)
            {
                return await Task.FromResult(
                    new Result<bool>()
                    {
                        Data = true,
                        Message = $"Workspace {request.Workspace.Name} creado correctamente.",
                        Success = true
                    });
            }
            else
            {
                return await Task.FromResult(
                    new Result<bool>()
                    {
                        Data = false,
                        Message = $"Error al crear workspace {request.Workspace.Name}.",
                        Success = false
                    });
            }
        }
    }
}

