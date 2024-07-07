using MediatR;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Dtos.Plastic.Repositories;

namespace TFGDevopsApp1.Mediator.Command.Repositories
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