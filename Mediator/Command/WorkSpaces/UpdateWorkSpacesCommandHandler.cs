using MediatR;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dto.Plastic.Workspaces;
using TFGDevopsApp1.Dtos.Plastic.Workspaces;

namespace TFGDevopsApp1.Mediator.Command.WorkSpaces
{
    public class UpdateWorkSpacesCommandHandler : IRequestHandler<UpdateWorkSpacesCommand, Result<bool>>
    {
        private readonly IConfiguration _configuration;
        public UpdateWorkSpacesCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<bool>> Handle(UpdateWorkSpacesCommand request, CancellationToken cancellationToken)
        {
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:PLASTIC_API_URL");
            if (string.IsNullOrEmpty(plasticBaseUrl))
                return await Task.FromResult(
                    new Result<bool>()
                    {
                        Data = true,
                        Message = $"No se puede editar workspace {request.Workspace}",
                        Success = false
                    });

            var response = RestClientHelper.Post<EditWorkspaceResponseDto, EditWorkspaceRequestDto>($"{plasticBaseUrl}/wkspaces", request.Workspace);

            if (response != null)
            {
                return await Task.FromResult(
                    new Result<bool>()
                    {
                        Data = true,
                        Message = $"Workspace {request.Workspace.Name} editado correctamente.",
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