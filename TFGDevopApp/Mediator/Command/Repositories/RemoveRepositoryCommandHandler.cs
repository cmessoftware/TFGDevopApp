using MediatR;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Command.Repositories
{
    public class RemoveRepositoryCommandHandler : IRequestHandler<RemoveRepositoryCommand, Result<bool>>
    {
        private readonly IConfiguration _configuration;

        public RemoveRepositoryCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<bool>> Handle(RemoveRepositoryCommand request, CancellationToken cancellationToken)
        {
            bool response = false;
            var plasticBaseUrl = _configuration.GetValue<string>("profiles:TFGDevops:environmentVariables:PlasticRest:Url");

            if (!string.IsNullOrEmpty(plasticBaseUrl))
            {
                var url = $"{plasticBaseUrl}api/v1/repos";
                response = RestClientHelper.Delete<bool, string>(url, request.Name);
            }


            if (response)
            {
                return await Task.FromResult(
                    new Result<bool>()
                    {
                        Data = response,
                        Message = $"Repositorio {request.Name} creado corectamente",
                        Success = true
                    });

            }
            else
            {
                return await Task.FromResult(
                    new Result<bool>()
                    {
                        Data = false,
                        Message = "No se pudo crear repositorio",
                        Success = false
                    });
            }
        }
    }
}
