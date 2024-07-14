using MediatR;
using TFGDevopsApp.Common;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dto.Plastic.Workspaces;
using TFGDevopsApp.Interfaces;

namespace TFGDevopsApp.Mediator.Command.WorkSpaces
{
    public class CreateWorkSpacesCommandHandler : IRequestHandler<CreateWorkSpacesCommand, Result<bool>>
    {
        private readonly IConfiguration _configuration;
        private readonly IPlasticServices _plasticServices;

        public CreateWorkSpacesCommandHandler(IConfiguration configuration,
                                              IPlasticServices plasticServices )
        {
            _configuration = configuration;
            _plasticServices = plasticServices;
        }

        public async Task<Result<bool>> Handle(CreateWorkSpacesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var plasticBaseUrl = _configuration.GetValue<string>(Constants.PlasticBaseUrlKey);

                if (string.IsNullOrEmpty(plasticBaseUrl))
                    return await Task.FromResult(
                        new Result<bool>()
                        {
                            Data = false,
                            Message = $"No se puede crear workspace {request.Workspace.Name}",
                            Success = false
                        });


                if (string.IsNullOrEmpty(request.Workspace.Path))
                {
                    var workspaces = await _plasticServices.GetWorkSpacesAsync("api/v1/wkspaces");

                    if (workspaces.Data.Any(w => w.Name == request.Workspace.Name))
                    {
                        return await Task.FromResult(
                                                   new Result<bool>()
                                                   {
                                                       Data = false,
                                                       Message = $"Ya existe un workspace con el nombre {request.Workspace.Name}",
                                                       Success = false
                                                   });
                    }

                    string parentDirectoryPath = Directory.GetParent(workspaces.Data.FirstOrDefault().Path).FullName;

                    request.Workspace.Path = $@"{parentDirectoryPath}\{request.Workspace.Name}";

                }

                var response = RestClientHelper.Post<bool, WorkspaceRequestDto>($"{plasticBaseUrl}api/v1/wkspaces", request.Workspace);

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
            catch (Exception ex)
            {
                return await Task.FromResult(
                                        new Result<bool>()
                                        {
                                            Data = false,
                                            Message = $"Error al crear workspace {request.Workspace.Name}. {ex.Message}",
                                            Success = false
                                        });
            }
        }
    }
}

