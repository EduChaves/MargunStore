using MargunStore.Domain.Commands.v1.Role.Create;
using MargunStore.Domain.Commands.v1.Role.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MargunStore.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand request)
        {
            await _mediator.Send(request);

            return Created(string.Empty, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}
