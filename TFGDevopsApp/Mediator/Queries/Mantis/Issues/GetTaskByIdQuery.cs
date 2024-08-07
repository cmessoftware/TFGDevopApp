﻿using MediatR;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Interfaces;

namespace TFGDevopsApp.Mediator.Queries.Mantis.Issues
{
    public class GetTaskByIdQuery : IRequest<Result<TaskByIdResponseDto>>
    {
        public GetTaskByIdQuery(string path, int id)
        {
            Id = id;
            Path = path;
        }

        public int Id { get; }
        public string Path { get; internal set; }
    }
}