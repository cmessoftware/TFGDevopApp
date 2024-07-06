﻿using MediatR;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Mediator.Command.Mantis
{
    public class CreateTaskCommand : IRequest<Result<Issue>>
    {
        private Issue request;

        public CreateTaskCommand(Issue request)
        {
            this.request = request;
        }
    }
}