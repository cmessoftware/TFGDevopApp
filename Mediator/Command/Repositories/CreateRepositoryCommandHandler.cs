using MediatR;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Repositories;

namespace TFGDevopsApp1.Mediator.Command.Repositories
{
    public class CreateRepositoryCommandHandler : IRequestHandler<CreateRepositoryCommand, Result<CreateRepositoryResponseDto>>
    {
        private readonly IConfiguration _configuration;

        public CreateRepositoryCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<CreateRepositoryResponseDto>> Handle(CreateRepositoryCommand request, CancellationToken cancellationToken)
        {
            CreateRepositoryResponseDto response = new();
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:PlasticRest:Url");

            if (!string.IsNullOrEmpty(plasticBaseUrl))
            {
                var url = $"{plasticBaseUrl}api/v1/repos";
                response = RestClientHelper.Post<CreateRepositoryResponseDto, RepositoryCreateRequestDto>(url, request.Repository);
            }


            if (response != null)
            {
                return await Task.FromResult(
                    new Result<CreateRepositoryResponseDto>()
                    {
                        Data = response,
                        Message = $"Repositorio {request.Repository.Name} creado correctamente",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<CreateRepositoryResponseDto>()
                    {
                        Data = null,
                        Message = "No se pudo crear repositorio",
                        Success = false
                    });
            }
        }
    }
}
