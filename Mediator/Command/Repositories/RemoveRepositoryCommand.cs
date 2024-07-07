using MediatR;
using TFGDevopsApp1.Core.Models.Result;

namespace TFGDevopsApp1.Mediator.Command.Repositories
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