using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Repositories;

namespace TFGDevopsApp.Mediator.Command.Repositories
{
    public class CreateRepositoryCommand : IRequest<Result<CreateRepositoryResponseDto>>
    {
        public RepositoryCreateRequestDto Repository { get; set; }

        public CreateRepositoryCommand(RepositoryCreateRequestDto repository)
        {
            repository.CreationDate = DateTime.Now;
            Repository = repository;
        }
    }
}