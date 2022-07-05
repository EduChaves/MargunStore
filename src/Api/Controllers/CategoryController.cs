using MargunStore.Domain.Commands.v1.Category.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MargunStore.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand request)
        {
            await _mediator.Send(request);

            return Created(string.Empty, null);
        }
    }
}
