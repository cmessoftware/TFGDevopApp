using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Plastic.Repositories;

namespace TFGDevopsApp.Mediator.Command.Repositories
{
    public class CreateRepositoryCommand : IRequest<ResultMessage<bool>>
    {
        public CreateRepositoryResponseDto Repository { get; set; }

        public CreateRepositoryCommand(CreateRepositoryResponseDto repository)
        {
            Repository = repository;
        }
    }
}