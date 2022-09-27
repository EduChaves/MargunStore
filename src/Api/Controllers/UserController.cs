﻿using MargunStore.Domain.Commands.v1.User.Create;
using MargunStore.Domain.Commands.v1.User.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MargunStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserCommand request)
        {
            var response = await _mediator.Send(request);

            return Created(string.Empty, response);
        }

        [HttpPost("login")]
        public async Task<LoginCommandResponse> Login(LoginCommand request) => await _mediator.Send(request);
    }
}
