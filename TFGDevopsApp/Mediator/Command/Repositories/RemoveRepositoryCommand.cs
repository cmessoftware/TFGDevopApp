using MediatR;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Command.Repositories
{
    public class RemoveRepositoryCommand : IRequest<Result<bool>>
    {
        public string Name { get; set; }

        public RemoveRepositoryCommand(string name)
        {
            Name = name;
        }
    }
}