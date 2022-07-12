using MargunStore.Domain.Commands.v1.Product.Create;
using MargunStore.Domain.Commands.v1.Product.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MargunStore.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand request)
        {
            await _mediator.Send(request);
            return Created(string.Empty, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
