using MediatR;
using System.Reflection.Metadata;
using TFGDevopsApp.Common;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Repositories;

namespace TFGDevopsApp.Mediator.Command.Repositories
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
            var plasticBaseUrl = _configuration.GetValue<string>(Constants.PlasticBaseUrlKey);

            if (!string.IsNullOrEmpty(plasticBaseUrl))
            {
                var url = $"{plasticBaseUrl}api/v1/repos";
                response = RestClientHelper.Post<CreateRepositoryResponseDto, RepositoryCreateRequestDto>(url, request.Repository);
            }
            else
            {
                return await Task.FromResult(
                 new Result<CreateRepositoryResponseDto>()
                 {
                     Data = response,
                     Message = $"Error: Repositorio {request.Repository.Name} - plasticBaseUrl es nulo",
                     Success = true
                 });


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
